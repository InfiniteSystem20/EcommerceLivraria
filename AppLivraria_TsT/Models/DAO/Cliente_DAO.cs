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
    }
}