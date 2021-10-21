using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class Cliente_DLL
    {
        Cliente_DAO dal = null;
        public Cliente_DLL() { }

        //SELECIONAR LISTA DE CLIENTE
        public List<Cliente_DTO> listaCliente()
        {
            try
            {
                dal = new Cliente_DAO();
                return dal.selectListCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SELECIONAR CLIENTE
        public DataTable selecionaCliente()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new Cliente_DAO();
                tb = dal.selectCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }
        //INSERIR CLIENTE
        public void novoCliente(Cliente_DTO clienteDto)
        {
            try
            {
                dal = new Cliente_DAO();
                dal.inserirCliente(clienteDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR LISTA DE CLIENTE DETALHES
        public List<Cliente_DTO> listaClienteDetalhes()
        {
            try
            {
                dal = new Cliente_DAO();
                return dal.selectListClienteDetalhes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}