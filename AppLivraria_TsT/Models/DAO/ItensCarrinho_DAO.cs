using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class ItensCarrinho_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public ItensCarrinho_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //Inserir Categoria
        public void inserirItensCarrinho(ItensCarrinho_DTO itensCarrinho)
        {

            try
            {
                String sql = "CALL proc_CadItensPedido(@IdPedido, @IdProd, @Qtd);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdPedido", itensCarrinho.IdPedido);
                cmd.Parameters.AddWithValue("@IdProd", itensCarrinho.IdProd);
                cmd.Parameters.AddWithValue("@Qtd", itensCarrinho.Qtd);

                con.Open();
                cmd.ExecuteNonQuery();
                // retorno = Convert.ToString(cmd.ExecuteScalar());                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro Itens do Pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro Itens do Pedido" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}