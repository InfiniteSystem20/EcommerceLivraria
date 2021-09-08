using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class cliente_DLL
    {
        clienteDAO_Acoes dal = null;
        public cliente_DLL() { }
        public DataTable selecionaCliente()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new clienteDAO_Acoes();
                tb = dal.selectCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }
        public void novoCliente(Cliente_DTO clienteDto)
        {
            try
            {
                dal = new clienteDAO_Acoes();
                dal.inserirCliente(clienteDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}