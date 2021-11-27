using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppLivraria_TsT.Controllers
{
    public class ClienteController : Controller
    {
        Cliente_DLL dll = new Cliente_DLL();
        Cliente_DTO clienteDTO = new Cliente_DTO();

        Cliente_DAO cliente_DAO = new Cliente_DAO();

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarClientes()
        {
            GridView dataGridListaCliente = new GridView();
            dataGridListaCliente.DataSource = dll.selecionaCliente();
            dataGridListaCliente.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dataGridListaCliente.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        public ActionResult CadCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadCliente(Cliente_DTO cliente)
        {
            if (ModelState.IsValid)
            {
                dll.novoCliente(cliente);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Login","Login");

                
                   /* return View();
                */
            }
            return View();

        }
        //Listar Cliente
        public ActionResult ListarCliente()
        {
            return View(dll.listaCliente());
        }
        //Listar Cliente Detalhes
        public ActionResult DetalhesCliente(int id)
        {
            return View(dll.listaClienteDetalhes().Find(clienteDTO => clienteDTO.IdCli == id));
        }
        //Listar Cliente Detalhes Painel
        public ActionResult DetalhesClientePainel(int id)
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(dll.listaClienteDetalhes().Find(clienteDTO => clienteDTO.IdCli == id));
            }
        }
        // EDITAR CLIENTE PAINEL        
        public ActionResult EditarClientePainel(int id)
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(dll.listaCliente().Find(clienteDTO => clienteDTO.IdCli == id));
            }
        }
        // EDITAR CLIENTE        
        public ActionResult EditarCliente(int id)
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(dll.listaCliente().Find(clienteDTO => clienteDTO.IdCli == id));
            }
        }
            // EDITAR CLIENTE
            [HttpPost]
        public ActionResult EditarCliente(Cliente_DTO cliente)
        {
            dll.alteraCliente(cliente);
            return RedirectToAction(nameof(ListarCliente));
        }
        // EXCLUIR CLIENTE
        public ActionResult ExcluirCliente(int id)
        {
            dll.exclurCliente(id);
            return RedirectToAction(nameof(ListarCliente));
        }
        public ActionResult DadosCliente(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(cliente_DAO.selectListClientePorId(id));
            }
        }
    }
}