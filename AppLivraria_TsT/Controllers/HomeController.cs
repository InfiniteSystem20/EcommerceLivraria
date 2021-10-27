using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
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
        Pedido_DTO PedidoDto = new Pedido_DTO();

        ItensCarrinho_DLL itensCarrinhodll = new ItensCarrinho_DLL();
        ItensCarrinho_DTO itensCarrinhoDto = new ItensCarrinho_DTO();

        public static string codigo;

        //Carrega os produtos  na Index
        public ActionResult Index()
        {
            return View(dll.listaProduto());
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

            return RedirectToAction("Carrinho");
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
            return RedirectToAction("Carrinho");
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
        public ActionResult CadastroCliente()
        {
            return View();
        }
        public ActionResult CarrinhoCompras()
        {
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