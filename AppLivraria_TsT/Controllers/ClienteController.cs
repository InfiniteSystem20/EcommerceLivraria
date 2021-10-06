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
                return RedirectToAction(nameof(CadCliente));

                /* ViewBag.msg = "Cliene cadastrado com sucesso!";
                    return View();
                */
            }
            return View();


        }
        public ActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCliente(Cliente_DTO cliente)
        {
            if (ModelState.IsValid)
            {
                dll.novoCliente(cliente);

                //TODO Imprementar redirecionamento diferenetes
                return RedirectToAction(nameof(CadastroCliente));

                /* ViewBag.msg = "Cliene cadastrado com sucesso!";
                    return View();
                */
            }
            return View();

        }

    }
}