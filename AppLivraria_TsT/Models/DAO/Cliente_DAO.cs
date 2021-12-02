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
    public class Cliente_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Cliente_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }

        //selecionar lista de Cliente
        public List<Cliente_DTO> selectListCliente()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL SelecionarCliente();", conn))
                    {
                        conn.Open();
                        List<Cliente_DTO> listaCliente = new List<Cliente_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Cliente_DTO cliente = new Cliente_DTO();
                                cliente.IdCli = (int)dr["IdCli"];
                                cliente.Nome = (String)dr["Nome"];
                                cliente.Nascimento = (String)dr["Nascimento"];
                                cliente.Sexo = (String)dr["Sexo"];
                                cliente.CPF = (String)dr["CPF"];
                                cliente.Telefone = (String)dr["Telefone"];
                                cliente.Celular = (String)dr["Celular"];
                                cliente.Email = (String)dr["Email"];
                                cliente.Senha = (String)dr["Senha"];

                                listaCliente.Add(cliente);
                            }
                        }
                        return listaCliente;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar cliente" + ex.Message);
            }
        }
        // Selecionar Lista cliente Detalhes
        public List<Cliente_DTO> selectListClienteDetalhes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarClienteDetalhes( )", conn))
                    {
                        conn.Open();
                        List<Cliente_DTO> listaCliente = new List<Cliente_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Cliente_DTO cliente = new Cliente_DTO();

                                cliente.IdCli = Convert.ToInt32(dr["IdCli"]);
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.CPF = dr["CPF"].ToString();
                                cliente.Nascimento = dr["Nascimento"].ToString();
                                cliente.Sexo = dr["Sexo"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Celular = dr["Celular"].ToString();                                
                                cliente.Email = dr["Email"].ToString();
                                cliente.Senha = dr["Senha"].ToString();
                                cliente.Tipo = dr["Tipo"].ToString();

                                cliente.TipoEndereco = dr["TipoEndereco"].ToString();
                                cliente.logradouro = dr["Logradouro"].ToString();
                                cliente.numero = Convert.ToInt32(dr["Numero"]);
                                cliente.complemento = dr["Complemento"].ToString();
                                cliente.bairro = dr["Bairro"].ToString();
                                cliente.CEP = dr["CEP"].ToString();
                                cliente.cidade = dr["Cidade"].ToString();
                                cliente.estado = dr["Estado"].ToString();
                                cliente.UF = dr["UF"].ToString();

                                listaCliente.Add(cliente);
                            }
                        }
                        return listaCliente;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar cliente" + ex.Message);
            }
        }

        // Selecionar Lista cliente Por Id
        public List<Cliente_DTO> selectListClientePorId(string id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarClientePorId( @IdCli )", conn))
                    {
                        command.Parameters.AddWithValue("@IdCli", id);
                        conn.Open();
                        List<Cliente_DTO> listaCliente = new List<Cliente_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Cliente_DTO cliente = new Cliente_DTO();

                                cliente.IdCli = Convert.ToInt32(dr["IdCli"]);
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.CPF = dr["CPF"].ToString();
                                cliente.Nascimento = dr["Nascimento"].ToString();
                                cliente.Sexo = dr["Sexo"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Celular = dr["Celular"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.Senha = dr["Senha"].ToString();
                                cliente.Tipo = dr["Tipo"].ToString();

                                cliente.TipoEndereco = dr["TipoEndereco"].ToString();
                                cliente.logradouro = dr["Logradouro"].ToString();
                                cliente.numero = Convert.ToInt32(dr["Numero"]);
                                cliente.complemento = dr["Complemento"].ToString();
                                cliente.bairro = dr["Bairro"].ToString();
                                cliente.CEP = dr["CEP"].ToString();
                                cliente.cidade = dr["Cidade"].ToString();
                                cliente.estado = dr["Estado"].ToString();
                                cliente.UF = dr["UF"].ToString();

                                listaCliente.Add(cliente);
                            }
                        }
                        return listaCliente;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar cliente" + ex.Message);
            }
        }
        //selecionar cliente
        public DataTable selectCliente()
        {
            try
            {
                String sql = "CALL SelecionarCliente();";
                con = new MySqlConnection(_conexaoMySQL);

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao selecionar Cliente " + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao selecionar Cliente" + ex.Message);
            }
        }
        //Inserir Cliente
        public void inserirCliente(Cliente_DTO cliente)
        {
            int Tipo = 1;
            string retorno;
            try
            {   
                String sql = "CALL proc_CadCliente(@nome, @Nascimento, @Sexo, @CPF, @Telefone, @Celular, @Email, @Senha, @Tipo );SELECT LAST_INSERT_ID();";
                
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", cliente.Nascimento);
                cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Senha", cliente.Senha);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);

                con.Open();
                retorno = Convert.ToString(cmd.ExecuteScalar());

                String sqlEnd = "CALL proc_CadEnderecoCli(@IdCli, @TipoEndereco, @Logradouro, @Numero, @Complemento, @Bairro, @CEP, @Cidade, @Estado, @UF);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd1 = new MySqlCommand(sqlEnd, con);
                cmd1.Parameters.AddWithValue("@IdCli", retorno);
                cmd1.Parameters.AddWithValue("@TipoEndereco", cliente.TipoEndereco);
                cmd1.Parameters.AddWithValue("@Logradouro", cliente.logradouro);
                cmd1.Parameters.AddWithValue("@Numero", cliente.numero);
                cmd1.Parameters.AddWithValue("@Complemento", cliente.complemento);
                cmd1.Parameters.AddWithValue("@Bairro", cliente.bairro);
                cmd1.Parameters.AddWithValue("@CEP", cliente.CEP);
                cmd1.Parameters.AddWithValue("@Cidade", cliente.cidade);
                cmd1.Parameters.AddWithValue("@Estado", cliente.estado);
                cmd1.Parameters.AddWithValue("@UF", cliente.UF);

                con.Open();
                cmd1.ExecuteNonQuery();

                String sqlLog = "CALL proc_CadLoginCli(@IdCli, @Tipo);";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd2 = new MySqlCommand(sqlLog, con);
                cmd2.Parameters.AddWithValue("@IdCli", retorno);
                cmd2.Parameters.AddWithValue("@Tipo", Tipo);
                con.Open();
                cmd2.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // UPDATE Cliente
        public void updateCliente(Cliente_DTO cliente)
        {
            try
            {
                String sql = " CALL proc_UpdateCliente(@IdCli, @Nome, @CPF, @Sexo, @Telefone, @Celular,@Nascimento, @Email, @Senha); ";

                //Alter Cliente
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Nascimento", cliente.Nascimento);                
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Senha", cliente.Senha);
                cmd.Parameters.AddWithValue("@IdCli", cliente.IdCli);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do cliente" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // DELETAR CLIENTE
        public void deleteCliente(int id)
        {
            try
            {
                String sql1 = "CALL  proc_DeleteEnderecoCli(@IdCli); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@IdCli", id);
                con.Open();
                cmd1.ExecuteNonQuery();


                String sql = "CALL  proc_DeleteCliente(@IdCli); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCli", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao deletar cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao deletar cliente" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}