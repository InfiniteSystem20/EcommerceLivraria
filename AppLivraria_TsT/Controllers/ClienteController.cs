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
        cliente_DLL dll = new cliente_DLL();
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
            dll.novoCliente(cliente);
            ViewBag.msg = "Cliene cadastrado com sucesso!";
            return View();
        }
    }
}