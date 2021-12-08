using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class DashbordController : Controller
    {
        // GET: Dashbord
        public ActionResult Index()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("LoginAdmin", "Login");
            }
            else
            {
                if (Session["tipologado1"] != null)
                {
                    ViewBag.message = "Você não tem acesso a essa página";
                    return RedirectToAction("semAcesso", "DashBord");

                }

            }
            return View();
        }
        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Você não tem acesso a essa página')</script>");
            ViewBag.message = "Você não tem acesso a essa página";
            return View();
        }
        public ActionResult semAcessoDash()
        {
            Response.Write("<script>alert('Você não tem acesso a essa página')</script>");
            ViewBag.message = "Você não tem acesso a essa página";
            return View();
        }
    }
}