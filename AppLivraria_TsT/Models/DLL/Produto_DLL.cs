using AppLivraria_TsT.Models.DAO;
using AppLivraria_TsT.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DLL
{
    public class Produto_DLL
    {
        Produto_DAO dal = null;
        public Produto_DLL() { }

        //INSERIR Produto
        public void novoProduto(Produto_DTO produto)
        {
            try
            {
                dal = new Produto_DAO();
                dal.inserirProduto(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //INSERIR Livro
        public void novoLivro(Produto_DTO produto)
        {
            try
            {
                dal = new Produto_DAO();
                dal.inserirLivro(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR LISTA DE Produto
        public List<Produto_DTO> listaProduto()
        {
            try
            {
                dal = new Produto_DAO();
                return dal.selectListProduto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR LISTA DE Produto detalhes
        public List<Produto_DTO> listaProdutoDetalhes()
        {
            try
            {
                dal = new Produto_DAO();
                return dal.selectListProdutoDetalhes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONAR PRODUTO POR ID
        public Produto_DTO listaProdutooPorID(int id)
        {
            try
            {
                dal = new Produto_DAO();
                return dal.selectProdutoByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}