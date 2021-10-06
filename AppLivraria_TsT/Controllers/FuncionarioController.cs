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
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadastroFuncionario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroFuncionario(Funcionario_DTO funcionario)
        {
            if (ModelState.IsValid)
            {
                dll.novoFuncionario(funcionario);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Cliene cadastrado com sucesso!";
                return RedirectToAction(nameof(CadastroFuncionario));
            }
            return View();
        }
    }
}