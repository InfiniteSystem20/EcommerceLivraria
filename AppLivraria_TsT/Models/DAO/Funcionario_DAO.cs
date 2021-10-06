using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Funcionario_DAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public Funcionario_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //INSERIR FUNCIONARIO
        public void inserirFuncionaario(Funcionario_DTO funcionario)
        {
            int Tipo = 2;

            try
            {
                String sql = "INSERT INTO tbCliente (Nome, Nascimento, Sexo, CPF,Telefone,Celular, Cargo, Email, Senha, Tipo)" +
                               " VALUES (@nome,@Nascimento,@Sexo,@CPF,@Telefone,@Celular,@Cargo, @Email,@Senha,@Tipo)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", funcionario.Nascimento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);                
                cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                cmd.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@Celular", funcionario.Celular);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                cmd.Parameters.AddWithValue("@Senha", funcionario.Senha);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro funcionário" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro funcionário" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}