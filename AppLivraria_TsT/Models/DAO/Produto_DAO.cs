using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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
                cmd.Parameters.AddWithValue("@PrecoUni", produto.PrecoUni).ToString().Replace(",", ".");
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
                cmd.Parameters.AddWithValue("@PrecoUni", produto.PrecoUni).ToString().Replace(",", ".");
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
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
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
        // Selecionar Lista produto Detalhes
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
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
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

        // Selecionar Lista produto por categoria
        public List<Produto_DTO> selectProdutoPorIdCategoria(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarCategoriaId(@IdCat);", conn))
                    {
                        command.Parameters.AddWithValue("@IdCat", id);
                        conn.Open();
                        List<Produto_DTO> listaProduto = new List<Produto_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Produto_DTO produto = new Produto_DTO();

                                produto.IdCat = Convert.ToString(dr["IdCat"]);
                                produto.IdProd = Convert.ToString(dr["IdProd"]);
                                produto.ISBN = dr["ISBN"].ToString();
                                produto.NomeProd = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                                produto.Autor = dr["Autor"].ToString();
                                produto.Categiria = dr["nome"].ToString();
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
                        PrecoUni = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ",")),
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
                                produto.PrecoUni = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
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
        // UPDATE Categoria
        public void updateProduto(Produto_DTO produto)
        {
            try
            {
                String sql = " CALL proc_UpdateProduto(@IdProd, @IdCat, @Nome, @Descricao, @PrecoUni, @Estoque, @Imagem,@ISBN, @Autor); ";

                //Alter Categoria
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProd", produto.IdProd);
                cmd.Parameters.AddWithValue("@IdCat", produto.IdCat);                
                cmd.Parameters.AddWithValue("@Nome", produto.NomeProd);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@PrecoUni", produto.PrecoUni).ToString().Replace(",", ".");
                cmd.Parameters.AddWithValue("@Estoque", Convert.ToInt32(produto.Estoque));                
                cmd.Parameters.AddWithValue("@Imagem", produto.Imagem);
                cmd.Parameters.AddWithValue("@Categiria", produto.Categiria);
                
                if (produto.Categiria != "Produto")
                {
                    cmd.Parameters.AddWithValue("@ISBN", produto.ISBN);
                    cmd.Parameters.AddWithValue("@Autor", produto.Autor);
                }                

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do categoria" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // DELETAR produto
        public void deleteProduto(int id)
        {
            try
            {
                String sql = "CALL  proc_DeleteProduto(@IdProd); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProd", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao deletar produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao deletar produto" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
    }
}