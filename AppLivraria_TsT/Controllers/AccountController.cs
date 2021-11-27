using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class AccountController : Controller
    {
        Categoria_DAO categoria_DAO = new Categoria_DAO();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public virtual PartialViewResult Menu()
        {
            IEnumerable<Categoria_DTO> Menu = null;

            if (Session["_Menu"] != null)
            {
                Menu = (IEnumerable<Categoria_DTO>)Session["_Menu"];
            }
            else
            {
                Menu = categoria_DAO.selectListCategoria();// pass employee id here
                Session["_Menu"] = Menu;
            }
            return PartialView("_Menu", Menu);
        }
    }
}