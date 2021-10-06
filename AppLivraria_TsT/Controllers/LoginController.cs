using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class LoginController : Controller
    {
        AcoesLogin acLg = new AcoesLogin();

       
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Cliente_DTO verLogin)
        {
            acLg.TestarUsuario(verLogin);
            if (verLogin.Email != null && verLogin.Senha != null)
            {
                Session["usuarioLogado"] = verLogin.Email.ToString();
                Session["senhaLogado"] = verLogin.Senha.ToString();
                Session["usuarioNome"] = verLogin.Nome.ToString();

                if (verLogin.Tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.Tipo.ToString(); //=1;
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.Tipo.ToString();//=2
                    return RedirectToAction("index", "Dashbord");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["usuarioNome"] = null;
            Session["tipoLogado1"] = null;
            Session["tipologado2"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogoutDash()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["usuarioNome"] = null;
            Session["tipoLogado1"] = null;
            Session["tipologado2"] = null;
            return RedirectToAction("Index", "Dashbord");
        }
    }
}