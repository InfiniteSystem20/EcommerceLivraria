using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{

    public class Categoria_DLL
    {
        Categoria_DAO dal = null;
        public Categoria_DLL() { }
        public void novaCategoria(Categoria_DTO categoria)
        {
            try
            {
                dal = new Categoria_DAO();
                dal.inserirCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}