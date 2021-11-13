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
    public class PedidoController : Controller
    {
        Pedido_DLL pedido_DLL = new Pedido_DLL();
        Pedido_DTO pedido_DTO = new Pedido_DTO();
        Pedido_DAO pedido_DAO = new Pedido_DAO();
            
            // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult PedidoCliente(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Session["idUser"] = id;
                return View(pedido_DAO.selectListPedidoPorIdCli(id));
            }
        }
    }
}