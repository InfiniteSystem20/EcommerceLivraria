﻿using AppLivraria_TsT.Models.DLL;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLivraria_TsT.Controllers
{
    public class CategoriaController : Controller
    {
        Categoria_DLL dll = new Categoria_DLL();
        Categoria_DTO categoriaDTO = new Categoria_DTO();
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadCategoria(Categoria_DTO categoria)
        {
            if (ModelState.IsValid)
            {
                dll.novaCategoria(categoria);

                //TODO Imprementar redirecionamento diferenetes
                ViewBag.msg = "Cliente cadastrado com sucesso!";
                return RedirectToAction(nameof(CadCategoria));


                /* return View();
             */
            }
            return View();

        }
    }
}