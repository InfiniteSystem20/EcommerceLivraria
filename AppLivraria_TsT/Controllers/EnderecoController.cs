using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class EnderecoController : Controller
    {
        Endereco_DTO endereco_DTO = new Endereco_DTO();
        Endereco_DAO endereco_DAO = new Endereco_DAO();
        // GET: Endereco
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarClienteEnderecoPorID(int id)
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(endereco_DAO.selectListClientePorId(id));
            }
        }
    }
}