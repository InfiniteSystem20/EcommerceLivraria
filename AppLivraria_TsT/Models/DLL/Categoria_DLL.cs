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
        //SELECIONAR LISTA DE Categoria
        public List<Categoria_DTO> listaCategoria()
        {
            try
            {
                dal = new Categoria_DAO();
                return dal.selectListCategoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //UPDATE Categoria
        public void alteraCategoria(Categoria_DTO categoria)
        {
            try
            {
                dal = new Categoria_DAO();
                dal.updateCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //EXCLUIR Categoria
        public void exclurCategoria(int id)
        {
            try
            {
                dal = new Categoria_DAO();
                dal.deleteCategoria(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}