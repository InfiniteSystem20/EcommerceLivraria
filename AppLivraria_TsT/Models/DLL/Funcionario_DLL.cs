using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class Funcionario_DLL
    {
        Funcionario_DAO dal = null;
        public Funcionario_DLL() { }
        
        //INSERIR FUNCIONARIO
        public void novoFuncionario(Funcionario_DTO funcionarioDto)
        {
            try
            {
                dal = new Funcionario_DAO();
                dal.inserirFuncionaario(funcionarioDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR FUNCIONARIO POR ID
        public Funcionario_DTO listafuncionarioPorID(int id)
        {
            try
            {
                dal = new Funcionario_DAO();
                return dal.selectFuncionarioByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR LISTA DE FUNCIONARIO
        public List<Funcionario_DTO> listaFuncionario()
        {
            try
            {
                dal = new Funcionario_DAO();
                return dal.selectListFuncionario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}