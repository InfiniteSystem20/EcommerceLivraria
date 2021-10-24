﻿using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class HomeController : Controller
    {
        Produto_DLL dll = new Produto_DLL();
        Produto_DTO produtoDto = new Produto_DTO();
        public ActionResult Index()
        {
            return View(dll.listaProduto());
        }
        public ActionResult Contato()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CadastroCliente()
        {
            return View();
        }
        public ActionResult CarrinhoCompras()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}