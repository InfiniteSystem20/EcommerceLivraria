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

        public ActionResult ListarTodosPedidos()
        {
            return View(pedido_DLL.listaPedido());
        }
        //Faturar Pedido
        public ActionResult FaturarPedido(string id)
        {
            pedido_DLL.alteraPedidoFaturar(id);
            return RedirectToAction(nameof(ListarTodosPedidos));
        }
        //Cancelar Pedido
        public ActionResult CancelarPedido(string id)
        {
            pedido_DLL.alteraPedidoCancelar(id);
            return RedirectToAction(nameof(ListarTodosPedidos));
        }
        //Cancelar Pedido
        public ActionResult CompletarPedido(string id)
        {
            pedido_DLL.alteraPedidoCompletar(id);
            return RedirectToAction(nameof(ListarTodosPedidos));
        }

        public ActionResult PedidoCliente(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {   
                return View(pedido_DAO.selectListPedidoPorIdCli(id));
            } 
        }
        
        public ActionResult PedidoClienteDetalhes(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(pedido_DAO.selectListPedidoPorIdCliDetalhes(id));
            }
        }

        public ActionResult ListarTodospedidoDetalhes(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(pedido_DAO.selectListPedidoPorIdCliDetalhes(id));
            }
        }
        public ActionResult PedidoDetalhes(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(pedido_DAO.ListarPedidoDetalhes().Find(pedido_DTO => pedido_DTO.IdPedido == id));
            }
        }
    }
}