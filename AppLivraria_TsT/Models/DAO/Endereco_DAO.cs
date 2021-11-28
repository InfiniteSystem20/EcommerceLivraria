using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Endereco_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Endereco_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }

        // Selecionar Lista cliente Por Id
        public List<Endereco_DTO> selectListClientePorId(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarClientePorId( @IdCli )", conn))
                    {
                        command.Parameters.AddWithValue("@IdCli", id);
                        conn.Open();
                        List<Endereco_DTO> listaEndereco = new List<Endereco_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Endereco_DTO endereco = new Endereco_DTO();
                                endereco.IdCli = dr["IdCli"].ToString();
                                endereco.IdEnd =Convert.ToInt32( dr["IdEnd"].ToString());
                                endereco.TipoEndereco = dr["TipoEndereco"].ToString();
                                endereco.logradouro = dr["Logradouro"].ToString();
                                endereco.numero = Convert.ToInt32(dr["Numero"]);
                                endereco.complemento = dr["Complemento"].ToString();
                                endereco.bairro = dr["Bairro"].ToString();
                                endereco.CEP = dr["CEP"].ToString();
                                endereco.cidade = dr["Cidade"].ToString();
                                endereco.estado = dr["Estado"].ToString();
                                endereco.UF = dr["UF"].ToString();

                                listaEndereco.Add(endereco);
                            }
                        }
                        return listaEndereco;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar Endereco" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar Endereco" + ex.Message);
            }
        }
    }
}