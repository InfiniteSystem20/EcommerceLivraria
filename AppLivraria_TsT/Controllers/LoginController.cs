using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult Login(Login verLogin)
        {
            acLg.TestarUsuarioGeral(verLogin);
            if (verLogin.Email != null && verLogin.Senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.Email, false);
                Session["usuarioLogado"] = verLogin.Email.ToString();
                Session["senhaLogado"] = verLogin.Senha.ToString();
                Session["usuarioNome"] = verLogin.Nome.ToString();
                Session["idUser"] = verLogin.IdCli.ToString();

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

        public ActionResult Login2(Login verLogin)
        {
            acLg.TestarUsuarioGeral(verLogin);
            if (verLogin.Email != null && verLogin.Senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.Email, false);
                Session["usuarioLogado"] = verLogin.Email.ToString();
                Session["senhaLogado"] = verLogin.Senha.ToString();
                Session["usuarioNome"] = verLogin.Nome.ToString();
                Session["idUser"] = verLogin.IdCli.ToString();

                if (verLogin.Tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.Tipo.ToString(); //=1;
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.Tipo.ToString();//=2
                    return RedirectToAction("index", "Dashbord");
                }
                return RedirectToAction("Carrinho", "Home");
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

        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(Login verLogin)
        {
            acLg.TestarUsuarioGeral(verLogin);
            if (verLogin.Email != null && verLogin.Senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.Email, false);
                Session["usuarioLogado"] = verLogin.Email.ToString();
                Session["senhaLogado"] = verLogin.Senha.ToString();
                Session["usuarioNome"] = verLogin.Nome.ToString();
                Session["IdFunc"] = verLogin.IdFunc.ToString();

                if (verLogin.Tipo == "2")
                {
                    Session["tipoLogado2"] = verLogin.Tipo.ToString(); //=2;
                    
                }
                else
                {
                    Session["tipoLogado1"] = verLogin.Tipo.ToString();//=1
                    //return RedirectToAction("SemAcesso", "Dashbord");
                }
                return RedirectToAction("Index", "Dashbord");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
            
        }
    }
}