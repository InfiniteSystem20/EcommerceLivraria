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
    }
}