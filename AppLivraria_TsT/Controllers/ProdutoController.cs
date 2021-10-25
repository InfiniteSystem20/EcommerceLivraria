using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class ProdutoController : Controller
    {
        //Carrega medico do dentista
        public void carregarCategoria()
        {
            List<SelectListItem> categorias = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("server=localhost;port=3307;user id=root;password=361190;database=Livraria01"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("CALL proc_SelecionarCategoria();", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categorias.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

            }

            ViewBag.cat = new SelectList(categorias, "Value", "Text");
        }

        Produto_DLL dll = new Produto_DLL();
        Produto_DTO produtoDto = new Produto_DTO();
        
        //Cadastrar Produto
        public ActionResult CadastroProduto()
        {
            carregarCategoria();
            return View();
        }
        //Cadastrar Produto
        [HttpPost]
        public ActionResult CadastroProduto(Produto_DTO produto, HttpPostedFileBase file)
        {
            carregarCategoria();
            produto.IdCat = Request["cat"];
          if (ModelState.IsValid)
            {

            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/images/produtos/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/images/produtos/"), arquivo);
            file.SaveAs(_path);
            produto.Imagem = file2;

            dll.novoProduto(produto);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Produto cadastrado com sucesso!";
                return RedirectToAction(nameof(CadastroProduto));
           }
          return View();
        }

        public ActionResult CadastroLivro()
        {
            carregarCategoria();
            return View();
        }
        //Cadastrar Produto
        [HttpPost]
        public ActionResult CadastroLivro(Produto_DTO produto, HttpPostedFileBase file)
        {
            carregarCategoria();
            produto.IdCat = Request["cat"];
            if (ModelState.IsValid)
            {

                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/images/produtos/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/images/produtos/"), arquivo);
                file.SaveAs(_path);
                produto.Imagem = file2;

                dll.novoLivro(produto);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Lirro cadastrado com sucesso!";
                return RedirectToAction(nameof(CadastroLivro));
            }
            return View();
        }
        //Listar Produtos
        public ActionResult ListarProdutos()
        {
            return View(dll.listaProduto());
        }
        //Listar Produtos detalhes
        public ActionResult DetalhesProduto(int id)
        {
            return View(dll.listaProdutoDetalhes().Find(produtoDto => produtoDto.IdProd == id));
        }
    }
}