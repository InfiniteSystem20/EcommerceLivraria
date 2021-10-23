using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class FuncionarioController : Controller
    {
        Funcionario_DLL dll = new Funcionario_DLL();
        Funcionario_DTO funcionarioDto = new Funcionario_DTO();
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        //Cadastrar Funcionario
        public ActionResult CadastroFuncionario()
        {
            return View();
        }
        //Cadastrar Funcionario
        [HttpPost]
        public ActionResult CadastroFuncionario(Funcionario_DTO funcionario)
        {
            if (ModelState.IsValid)
            {
                dll.novoFuncionario(funcionario);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Cliene cadastrado com sucesso!";
                return RedirectToAction(nameof(ListarFuncionario));
            }
            return View();
        }

        //Listar Funcionario
        public ActionResult ListarFuncionario()
        {

            return View(dll.listaFuncionario());
        }
        //Listar Funcionario Detalhes
        public ActionResult DetalhesFuncionario(int id)
        {
            return View(dll.listaFuncionarioDetalhes().Find(funcionarioDto => funcionarioDto.IdFunc == id));
        }


        // EDITAR CLIENTE        
        public ActionResult EditarFuncionario(int id)
        {
            //  if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            //  {
            //      return RedirectToAction("Index", "Home");
            //  }
            //  else
            //   {
            return View(dll.listaFuncionario().Find(funcionarioDto => funcionarioDto.IdFunc == id));
            //  }
        }
        //EDITAR FUNCIONARIO
        [HttpPost]
        public ActionResult EditarFuncionario(Funcionario_DTO funcionario)
        {
            dll.alteraFuncionario(funcionario);
            return RedirectToAction(nameof(ListarFuncionario));
        }
        // Excluir Funcionario      
        //public ActionResult ExcluirFuncionario(int id)
        //{
        //    //  if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
        //    //  {
        //    //      return RedirectToAction("Index", "Home");
        //    //  }
        //    //  else
        //    //   {
        //    return View(dll.listaFuncionario().Find(funcionarioDto => funcionarioDto.IdFunc == id));

        //    //  }
        //}

        //EXCLUIR FNCIONARIO
        public ActionResult ExcluirFuncionario(int id)
        {
            dll.exclurFuncionario(id);
            return RedirectToAction(nameof(ListarFuncionario));
        }

    }
}