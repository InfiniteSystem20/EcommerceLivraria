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
                String sql = "INSERT INTO tbFuncionario (Nome, Nascimento, Sexo, CPF,Telefone,Celular, Cargo, Email, Senha, Tipo)" +
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
        // SELECIONAR FUNCIONARIO POR ID
        public Funcionario_DTO selectFuncionarioByID(int id)
        {
            try
            {
                String sql = "call proc_SelectFuncById(IdFunc)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdFunc", id);
                con.Open();
                MySqlDataReader dr;
                Funcionario_DTO funcionario = new Funcionario_DTO();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    funcionario.IdFunc = Convert.ToInt32(dr["IdFunc"]);
                    funcionario.Nome = dr["Nome"].ToString();
                    funcionario.CPF = dr["CPF"].ToString();
                    funcionario.Nascimento = dr["Nascimento"].ToString();
                    funcionario.Sexo = dr["Sexo"].ToString();                   
                    funcionario.Telefone = dr["Telefone"].ToString();
                    funcionario.Celular = dr["CEP"].ToString();
                    funcionario.Cargo = dr["Cargo"].ToString();
                    funcionario.Email = dr["Email"].ToString();
                    funcionario.Senha = dr["Senha"].ToString();
                    funcionario.Tipo = dr["Tipo"].ToString();

                }
                return funcionario;

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao localizar funcionario pelo codigo" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao localizar funcionario pelo codigo" + ex.Message);
            }
        }
        // Selecionar Lista Funcionario
        public List<Funcionario_DTO> selectListFuncionario()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("Select * from tbFuncionario", conn))
                    {
                        conn.Open();
                        List<Funcionario_DTO> listaFuncionario = new List<Funcionario_DTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Funcionario_DTO funcionario = new Funcionario_DTO();                             

                                funcionario.IdFunc = Convert.ToInt32(dr["IdFunc"]);
                                funcionario.Nome = dr["Nome"].ToString();
                                funcionario.CPF = dr["CPF"].ToString();
                                funcionario.Nascimento = dr["Nascimento"].ToString();
                                funcionario.Sexo = dr["Sexo"].ToString();
                                funcionario.Telefone = dr["Telefone"].ToString();
                                funcionario.Celular = dr["Celular"].ToString();
                                funcionario.Cargo = dr["Cargo"].ToString();
                                funcionario.Email = dr["Email"].ToString();
                                funcionario.Senha = dr["Senha"].ToString();
                                funcionario.Tipo = dr["Tipo"].ToString();

                                //funcionario.IdFunc = (int)dr["IdFunc"];
                                //funcionario.Nome = (String)dr["Nome"];
                                //funcionario.CPF = (String)dr["CPF"];
                                //funcionario.Nascimento = (String)dr["Nascimento"];
                                //funcionario.Sexo = (String)dr["Sexo"];

                                listaFuncionario.Add(funcionario);

                                
                            }
                        }
                        return listaFuncionario;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar endereço" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar endereço" + ex.Message);
            }
        }
    }
}