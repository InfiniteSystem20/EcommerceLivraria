using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class ItensCarrinho_DLL
    {
        ItensCarrinho_DAO dal = null;
        public ItensCarrinho_DLL() { }

        public void novaItensCarrinho(ItensCarrinho_DTO itensCarrinho)
        {
            try
            {
                dal = new ItensCarrinho_DAO();
                dal.inserirItensCarrinho(itensCarrinho);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}