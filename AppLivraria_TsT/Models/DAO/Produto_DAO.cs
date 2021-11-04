using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Produto_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Produto_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //Inserir Produto
        public void inserirProduto(Produto_DTO produto)
        {

            try
            {
                String sql = "CALL proc_CadProduto(@IdCat,@nome, @Descricao, @PrecoUni, @Estoque, @Imagem);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCat", produto.IdCat);
                cmd.Parameters.AddWithValue("@Nome", produto.NomeProd);                
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@PrecoUni", produto.PrecoUni);
                cmd.Parameters.AddWithValue("@Estoque",Convert.ToInt32( produto.Estoque));
                cmd.Parameters.AddWithValue("@Imagem", produto.Imagem);                
                con.Open();
                cmd.ExecuteNonQuery();
                // retorno = Convert.ToString(cmd.ExecuteScalar());                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro produto" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //Inserir Categoria
        public void inserirLivro(Produto_DTO produto)
        {

            try
            {
                String sql = "CALL proc_CadLivro(@IdCat,@ISBN, @nome, @Descricao, @PrecoUni, @Estoque, @Autor, @Imagem);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCat", produto.IdCat);
                cmd.Parameters.AddWithValue("@ISBN", produto.ISBN);
                cmd.Parameters.AddWithValue("@Nome", produto.NomeProd);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@PrecoUni", produto.PrecoUni);
                cmd.Parameters.AddWithValue("@Estoque", Convert.ToInt32(produto.Estoque));
                cmd.Parameters.AddWithValue("@Autor", produto.Autor);
                cmd.Parameters.AddWithValue("@Imagem", produto.Imagem);
                con.Open();
                cmd.ExecuteNonQuery();
                // retorno = Convert.ToString(cmd.ExecuteScalar());                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro produto" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // Selecionar Lista Produto
        public List<Produto_DTO> selectListProduto()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarProduto( )", conn))
                    {
                        conn.Open();
                        List<Produto_DTO> listaProduto = new List<Produto_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Produto_DTO produto = new Produto_DTO();

                                produto.IdProd = Convert.ToString(dr["IdProd"]);
                                produto.ISBN = dr["ISBN"].ToString();
                                produto.NomeProd = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.PrecoUni = Convert.ToDecimal( dr["PrecoUni"]);
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                                produto.Autor = dr["Autor"].ToString();
                                produto.Imagem = dr["Imagem"].ToString();


                                listaProduto.Add(produto);
                            }
                        }
                        return listaProduto;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar Produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar Produto" + ex.Message);
            }
        }
        // Selecionar Lista cliente Detalhes
        public List<Produto_DTO> selectListProdutoDetalhes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarProdutoDetalhes( )", conn))
                    {
                        conn.Open();
                        List<Produto_DTO> listaProduto = new List<Produto_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Produto_DTO produto = new Produto_DTO();

                                produto.IdProd = Convert.ToString(dr["IdProd"]);
                                produto.ISBN = dr["ISBN"].ToString();
                                produto.NomeProd = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"]);
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                                produto.Autor = dr["Autor"].ToString();
                                produto.Categiria = dr["Categoria"].ToString();
                                produto.Imagem = dr["Imagem"].ToString();


                                listaProduto.Add(produto);
                            }
                        }
                        return listaProduto;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar produto" + ex.Message);
            }
        }
        // SELECIONAR FUNCIONARIO POR ID
        public Produto_DTO selectProdutoByID(int id)
        {
            try
            {
                //String sql = "call proc_SelectProdutoById(IdProd)";
                String sql = "SELECT * FROM Tbproduto where IdProd = @IdProd)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProd", id);
                con.Open();
                MySqlDataReader dr;
                Produto_DTO produto = new Produto_DTO();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    produto.IdProd = dr["IdProd"].ToString();
                    produto.ISBN = dr["ISBN"].ToString();
                    produto.NomeProd = dr["Nome"].ToString();
                    produto.Descricao = dr["Descricao"].ToString();
                    produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"]);
                    produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                    produto.Autor = dr["Autor"].ToString();
                    produto.Categiria = dr["Categoria"].ToString();
                    produto.Imagem = dr["Imagem"].ToString();

                }
                return produto;

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao localizar funcionario pelo codigo" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao localizar funcionario pelo codigo" + ex.Message);
            }
        }

        public List<Produto_DTO> GetConsProd(int id)
        {
            List<Produto_DTO> Produtoslist = new List<Produto_DTO>();

            //String sql = "call proc_SelectProdutoById(@IdProd)";
            String sql = "SELECT * FROM Tbproduto where IdProd = @IdProd)";
            con = new MySqlConnection(_conexaoMySQL);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@IdProd", id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.Open();

            foreach (DataRow dr in dt.Rows)
            {
                Produtoslist.Add(
                    new Produto_DTO
                    {
                        IdProd = Convert.ToString(dr["IdProd"]),
                        NomeProd = Convert.ToString(dr["Nome"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        PrecoUni = Convert.ToDecimal(dr["PrecoUni"]),
                        Estoque = Convert.ToInt32(dr["Estoque"]),
                        Imagem = Convert.ToString(dr["Imagem"])
                    });
            }
            return Produtoslist;
        }
        //Listar Produto por ID
        public List<Produto_DTO> selectListProdutoId( int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM Tbproduto where IdProd = @IdProd", conn))
                    {
                        command.Parameters.AddWithValue("@IdProd", id);
                        conn.Open();
                        List<Produto_DTO> listaProduto = new List<Produto_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Produto_DTO produto = new Produto_DTO();

                                produto.IdProd = Convert.ToString(dr["IdProd"]);
                                produto.ISBN = dr["ISBN"].ToString();
                                produto.NomeProd = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"]);
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                                produto.Autor = dr["Autor"].ToString();
                                produto.Imagem = dr["Imagem"].ToString();


                                listaProduto.Add(produto);
                            }
                        }
                        return listaProduto;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar Produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar Produto" + ex.Message);
            }
        }
    }
}