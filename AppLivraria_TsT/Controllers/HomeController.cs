using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class HomeController : Controller
    {       
        //Classe de produtos
        Produto_DLL dll = new Produto_DLL();
        Produto_DTO produtoDto = new Produto_DTO();
        Produto_DAO produto_DAO = new Produto_DAO();

        Pedido_DLL pedidodll = new Pedido_DLL();
        Pedido_DTO pedidoDto = new Pedido_DTO();
        Pedido_DAO pedido_DAO = new Pedido_DAO();

        ItensCarrinho_DLL itensCarrinhodll = new ItensCarrinho_DLL();
        ItensCarrinho_DTO itensCarrinhoDto = new ItensCarrinho_DTO();

        public static string codigo;

        Categoria_DLL categoriadll = new Categoria_DLL();
        Categoria_DTO categoriaDTO = new Categoria_DTO();
        Categoria_DAO categoria_DAO = new Categoria_DAO();

       

        //Carrega os produtos  na Index
        public ActionResult Index()
        {
            //carregarCategoria();
            return View(dll.listaProdutoHome());
        }
        //Carrega os produtos  na categoria Index
        public ActionResult CategoriaIndex()
        {
            //carregarCategoria();

            //produtoDto.IdCat = Request["cat"];
            //categoriadll.listaCategoria();  
            return View(categoria_DAO.selectListCategoria());

            //return View(dll.listaProduto());
        }
        public ActionResult ProdutoCategoriaIndex(int id)
        {           
            return View(produto_DAO.selectProdutoPorIdCategoria(id));     
            
        }
        
        // Detalhes do Produto
        public ActionResult detalhe(string id)
        {
            return View(dll.listaProdutoDetalhes().Find(produtoDto => produtoDto.IdProd == id));
        }

        public ActionResult AdicionarCarrinho(int id, decimal pre, string imagem)
        {
            Pedido_DTO carrinho = Session["Carrinho"] != null ? (Pedido_DTO)Session["Carrinho"] : new Pedido_DTO();


            var produto = produto_DAO.selectListProdutoId(id);
            codigo = id.ToString();

            Produto_DTO prod = new Produto_DTO();
           

            if (produto != null)
            {
                var itemPedido = new ItensCarrinho_DTO();

                itemPedido.IdItensCar = Guid.NewGuid();
                itemPedido.IdProd = id.ToString();
                itemPedido.Produto = produto[0].NomeProd;
                itemPedido.Imagem = imagem.ToString();
                itemPedido.Qtd = 1;
                
                itemPedido.valorUnit = pre;

                List<ItensCarrinho_DTO> x = carrinho.ItensPedido.FindAll(l => l.Produto == itemPedido.Produto);

                if (x.Count != 0)
                {
                    carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NomeProd).Qtd += 1;
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.valorUnit;
                    carrinho.ValorTotal += itemPedido.valorParcial;
                    carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NomeProd).valorParcial = carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NomeProd).Qtd * itemPedido.valorUnit;

                }
                else
                {
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.valorUnit;
                    carrinho.ValorTotal += itemPedido.valorParcial;
                    carrinho.ItensPedido.Add(itemPedido);
                }

                /*carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto).Sum(d => d.Valor);*/

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction(nameof(Carrinho));
        }
        public ActionResult Carrinho()
        {
            Pedido_DTO carrinho = Session["Carrinho"] != null ? (Pedido_DTO)Session["Carrinho"] : new Pedido_DTO();

            return View(carrinho);
        }
        //Excluir Itens do carrinho
        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (Pedido_DTO)Session["Carrinho"] : new Pedido_DTO();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(i => i.IdItensCar == id);

            carrinho.ValorTotal -= itemExclusao.valorParcial;

            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction(nameof(Carrinho));
        }
      
        public ActionResult SalvarCarrinho(Pedido_DTO x)
        {
            
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var carrinho = Session["Carrinho"] != null ? (Pedido_DTO)Session["Carrinho"] : new Pedido_DTO();

                Pedido_DTO md = new Pedido_DTO();
                ItensCarrinho_DTO mdV = new ItensCarrinho_DTO();

                md.DtPedido = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy");
                md.HoraPedido = DateTime.Now.ToLocalTime().ToString("HH:mm");
                md.IdCli = Session["idUser"].ToString();
                md.ValorTotal = carrinho.ValorTotal;

                pedidodll.novoPedido(md);

                
                pedido_DAO.buscaIdVenda(x);

                for (int i = 0; i < carrinho.ItensPedido.Count; i++)
                {

                    mdV.IdPedido = x.IdPedido;
                    mdV.IdProd = carrinho.ItensPedido[i].IdProd;
                    mdV.Qtd = carrinho.ItensPedido[i].Qtd;
                    mdV.valorParcial = carrinho.ItensPedido[i].valorParcial;
                    itensCarrinhodll.novaItensCarrinho(mdV);

                }

                carrinho.ValorTotal = 0;
                ViewBag.pedido = x.IdPedido;
                carrinho.ItensPedido.Clear();
                
                return RedirectToAction(nameof(Finalizado));
            }
        }
        public ActionResult Finalizado(Pedido_DTO x)
        {
            pedido_DAO.buscaIdVenda(x);
            pedidoDto.IdPedido = x.IdPedido;
            ViewBag.pedido = x.IdPedido;
            return View(itensCarrinhodll.listaItensCarrinhoDetalhes().Find(pedidoDto => pedidoDto.IdPedido == x.IdPedido));         
        }
        public ActionResult FinalizadoDetalhes(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }            

            return View(itensCarrinhodll.listaItensCarrinhoDetalhes().Find(itensCarrinhoDto => itensCarrinhoDto.IdPedido == id));

        }
        public ActionResult ListarCategoriaHome()
        {
            return View(categoriadll.listaCategoria());
        }
        public ActionResult Checkout(string id)
        {

            return View(itensCarrinhodll.listaItensCarrinhoDetalhes().Find(pedidoDto => pedidoDto.IdPedido == id));
        }

        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        public ActionResult PainelControle()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}