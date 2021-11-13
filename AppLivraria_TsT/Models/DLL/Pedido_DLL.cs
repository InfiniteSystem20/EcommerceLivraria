using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class Pedido_DLL
    {
        Pedido_DAO dal = null;
        public Pedido_DLL() { }

        //Inserir Pedido
        public void novoPedido(Pedido_DTO pedido)
        {
            try
            {
                dal = new Pedido_DAO();
                dal.inserirPedido(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR Pedido por ID
        public List<Pedido_DTO> listaPedidoPorID()
        {
            try
            {
                dal = new Pedido_DAO();
                return dal.buscaPedidoPorId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SELECIONAR Pedido por Cliente
        //public List<Pedido_DTO> listaPedidoPorIDCliente()
        //{
        //    try
        //    {
        //        dal = new Pedido_DAO();
        //        return dal.selectListPedidoPorIdCli(string id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}