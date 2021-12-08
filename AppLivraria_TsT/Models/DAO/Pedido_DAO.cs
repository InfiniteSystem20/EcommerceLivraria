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
            string StatusPedido = "Pendente";
            try
            {
                String sql = "CALL proc_CadPedido(@IdCli, @DtPedido, @HoraPedido, @ValorTotal, @StatusPedido );";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCli", pedido.IdCli);
                cmd.Parameters.AddWithValue("@DtPedido", pedido.DtPedido);
                cmd.Parameters.AddWithValue("@HoraPedido", pedido.HoraPedido);
                cmd.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
                cmd.Parameters.AddWithValue("@StatusPedido", StatusPedido);

                con.Open();
                cmd.ExecuteNonQuery();
                // retorno = Convert.ToString(cmd.ExecuteScalar());                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro pedido" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // Selecionar Lista Pedido
        public List<Pedido_DTO> selectListPedido()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarPedido( )", conn))
                    { 
                        conn.Open();
                        List<Pedido_DTO> listaPedido = new List<Pedido_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Pedido_DTO pedido = new Pedido_DTO();

                                pedido.IdPedido = dr["IdPedido"].ToString();
                                pedido.IdCli = dr["IdCli"].ToString();
                                pedido.DtPedido = dr["DtPedido"].ToString();
                                pedido.HoraPedido = dr["HoraPedido"].ToString();
                                pedido.ValorTotal = Convert.ToDecimal(dr["ValorTotal"].ToString().Replace(".", ","));
                                pedido.StatusPedido = dr["StatusPedido"].ToString();
                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
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
        // Selecionar Lista Pedido
        public List<Pedido_DTO> ListarPedidoDetalhes()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarPedidoDetalhes( )", conn))
                    {
                        conn.Open();
                        List<Pedido_DTO> listaPedido = new List<Pedido_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Pedido_DTO pedido = new Pedido_DTO();

                                pedido.IdPedido = dr["IdPedido"].ToString();
                                pedido.IdCli = dr["IdCli"].ToString();
                                pedido.DtPedido = dr["DtPedido"].ToString();
                                pedido.HoraPedido = dr["HoraPedido"].ToString();
                                pedido.ValorTotal = Convert.ToDecimal(dr["ValorTotal"].ToString().Replace(".", ","));
                                pedido.StatusPedido = dr["StatusPedido"].ToString();
                                pedido.Nome = dr["Nome"].ToString();
                                pedido.Email = dr["Email"].ToString();
                                pedido.CPF = dr["CPF"].ToString();

                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
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
        //Listar Produto por ID em uso
        public void buscaIdVenda(Pedido_DTO pedido)
        {

            //MySqlDataReader dr;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT IdPedido FROM tbPedido ORDER BY IdPedido DESC limit 1;", conn))
                    {
                        conn.Open();                        
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                pedido.IdPedido = dr[0].ToString();
                            }
                            
                        }
                    }
                 }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro pedido" + ex.Message);
            }
        
        }

        // Selecionar Lista Pedido por cliente
        public List<Pedido_DTO> selectListPedidoPorIdCli(string id)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarPedidoIdCliente( @IdCli)", conn))
                    {
                        command.Parameters.AddWithValue("@IdCli", id);
                        conn.Open();
                        List<Pedido_DTO> listaPedido = new List<Pedido_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Pedido_DTO pedido = new Pedido_DTO();

                                pedido.IdPedido = dr["IdPedido"].ToString();
                                pedido.IdCli = dr["IdCli"].ToString();
                                pedido.DtPedido = dr["DtPedido"].ToString();
                                pedido.HoraPedido = dr["HoraPedido"].ToString();
                                pedido.ValorTotal = Convert.ToDecimal(dr["ValorTotal"].ToString().Replace(".", ","));
                                pedido.StatusPedido = dr["StatusPedido"].ToString();
                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
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
        // Selecionar Lista Pedido por cliente Detalhes
        public List<ItensCarrinho_DTO> selectListPedidoPorIdCliDetalhes(string id)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarItensPedidoDetalhesId( @IdPedido)", conn))
                    {
                        command.Parameters.AddWithValue("@IdPedido", id);
                        conn.Open();
                        List<ItensCarrinho_DTO> listaPedido = new List<ItensCarrinho_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ItensCarrinho_DTO pedido = new ItensCarrinho_DTO();
                                pedido.IdPedido = dr["IdPedido"].ToString();
                                pedido.IdCli = dr["IdCli"].ToString();
                                pedido.DtPedido = dr["DtPedido"].ToString();
                                pedido.IdProd = dr["IdProd"].ToString();
                                pedido.Imagem = dr["Imagem"].ToString();
                                pedido.Produto = dr["nome"].ToString();
                                pedido.HoraPedido = dr["HoraPedido"].ToString();
                                pedido.Qtd = Convert.ToInt32(dr["Qtd"].ToString());
                                pedido.valorUnit = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
                                pedido.ValorTotal = Convert.ToDecimal(dr["ValorTotal"].ToString().Replace(".", ","));                            
                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
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
        // Selecionar Lista Pedido todos clientes Detalhes
        public List<ItensCarrinho_DTO> selectListPedidoDetalhes()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarItensPedidoDetalhes( )", conn))
                    {
                        //command.Parameters.AddWithValue("@IdPedido", id);
                        conn.Open();
                        List<ItensCarrinho_DTO> listaPedido = new List<ItensCarrinho_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ItensCarrinho_DTO pedido = new ItensCarrinho_DTO();
                                pedido.IdPedido = dr["IdPedido"].ToString();
                                pedido.IdCli = dr["IdCli"].ToString();
                                pedido.DtPedido = dr["DtPedido"].ToString();
                                pedido.IdProd = dr["IdProd"].ToString();
                                pedido.Imagem = dr["Imagem"].ToString();
                                pedido.Produto = dr["nome"].ToString();
                                pedido.HoraPedido = dr["HoraPedido"].ToString();
                                pedido.Qtd = Convert.ToInt32(dr["Qtd"].ToString());
                                pedido.valorUnit = Convert.ToDecimal(dr["PrecoUni"].ToString().Replace(".", ","));
                                pedido.ValorTotal = Convert.ToDecimal(dr["ValorTotal"].ToString().Replace(".", ","));
                                listaPedido.Add(pedido);
                            }
                        }
                        return listaPedido;
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
        // UPDATE PEDIDO FATURAR
        public void updatePedidoFaturar(string id)
        {
            string StatusPedido = "Pago";
            try
            {
                String sql = " CALL proc_UpdateStatusPedido(@IdPedido, @StatusPedido); ";

                //Alter Funcionario
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@IdPedido", id);
                cmd.Parameters.AddWithValue("@StatusPedido", StatusPedido);


                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do pedido" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // UPDATE PEDIDO CANCELAAR
        public void updatePedidoCancelar(string id)
            {
            string StatusPedido = "Cancelado";
                try
                {
                    String sql = " CALL proc_UpdateStatusPedido(@IdPedido, @StatusPedido); ";

                    //Alter Funcionario
                    con = new MySqlConnection(_conexaoMySQL);
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@IdPedido", id);
                    cmd.Parameters.AddWithValue("@StatusPedido", StatusPedido);
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {

                    throw new Exception("Erro no banco ao atualizar dados do pedido" + ex.Message);
                }
                catch (Exception ex)
                {

                    throw new Exception("Erro na aplicação ao atualizar dados do pedido" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        // UPDATE PEDIDO COMPLETAR
        public void updatePedidoCompletar(string id)
        {
            string StatusPedido = "Completo";
            try
            {
                String sql = " CALL proc_UpdateStatusPedido(@IdPedido, @StatusPedido); ";

                //Alter Funcionario
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@IdPedido", id);
                cmd.Parameters.AddWithValue("@StatusPedido", StatusPedido);


                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do pedido" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do pedido" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}