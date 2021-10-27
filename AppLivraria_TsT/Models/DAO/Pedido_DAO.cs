using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Pedido_DAO
    {

        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Pedido_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //Inserir Pedido
        public void inserirPedido(Pedido_DTO pedido)
        {

            try
            {
                String sql = "CALL proc_CadPedido(@IdCli, @DtPedido, @HoraPedido, @ValorTotal );";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCli", pedido.IdCli);
                cmd.Parameters.AddWithValue("@DtPedido", pedido.DtPedido);
                cmd.Parameters.AddWithValue("@HoraPedido", pedido.HoraPedido);
                cmd.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
                
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

        //MySqlDataReader dr;
        //public void buscaIdVenda(Pedido_DTO vend)
        //{
        //    MySqlCommand cmd = new MySqlCommand("SELECT codVenda FROM tbVenda ORDER BY codVenda DESC limit 1", con.MyConectarBD());
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        vend.codVenda = dr[0].ToString();
        //    }
        //    con.MyDesconectarBD();
        //}


        //selecionar lista de Pedido
        public List<Pedido_DTO> buscaPedidoPorId()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT IdPedido FROM tbPedido ORDER BY IdPedido DESC limit 1;", conn))
                    {
                        conn.Open();
                        List<Pedido_DTO> listaPedido = new List<Pedido_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Pedido_DTO pedido = new Pedido_DTO();
                                pedido.IdPedido = (string)dr["IdPedido"];

                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar Pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar Pedido" + ex.Message);
            }
        }
    }
}