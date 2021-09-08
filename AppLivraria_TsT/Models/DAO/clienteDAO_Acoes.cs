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
    public class clienteDAO_Acoes
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public clienteDAO_Acoes()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        public List<Cliente_DTO> selectListCliente()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("Select * from cliente", conn))
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
                                cliente.Email = (String)dr["Email"];
                                cliente.Senha = (String)dr["Senha"];
                                // cliente.Veiculo.IdVeiculo = (int)dr["idveiculo"];
                                //  cliente.Usuario.Codigo = (int)dr["id"];


                                listaCliente.Add(cliente);
                            }
                        }
                        return listaCliente;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar usuario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar usuario" + ex.Message);
            }
        }

        public DataTable selectCliente()
        {
            try
            {
                String sql = "SELECT * FROM tbCliente;";
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


    }
}