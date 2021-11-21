using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Categoria_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Categoria_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //Inserir Categoria
        public void inserirCategoria(Categoria_DTO categoria)
        {

            try
            {
                String sql = "CALL proc_CadCategoria(@nome);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                // retorno = Convert.ToString(cmd.ExecuteScalar());                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro categoria" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //selecionar lista de Categoria
        public List<Categoria_DTO> selectListCategoria()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarCategoria();", conn))
                    {
                        conn.Open();
                        List<Categoria_DTO> listaCategoria = new List<Categoria_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Categoria_DTO categoria = new Categoria_DTO();
                                categoria.IdCat = Convert.ToInt32( dr["IdCat"]);
                                categoria.Nome = (String)dr["Nome"];


                                listaCategoria.Add(categoria);
                            }
                        }
                        return listaCategoria;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar categoria" + ex.Message);
            }
        }
        // UPDATE Categoria
        public void updateCategoria(Categoria_DTO categoria)
        {
            try
            {
                String sql = " CALL proc_UpdateCategoria(@IdCat, @Nome); ";

                //Alter Categoria
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);                
                cmd.Parameters.AddWithValue("@IdCat", categoria.IdCat);

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
        // DELETAR Categoria
        public void deleteCategoria(int id)
        {
            try
            {
                String sql = "CALL  proc_DeleteCategoria(@IdCat); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCat", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao deletar categoria" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao deletar categoria" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}