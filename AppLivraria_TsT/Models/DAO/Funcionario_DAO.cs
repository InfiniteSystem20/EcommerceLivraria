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
        
        public Funcionario_DAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        //INSERIR FUNCIONARIO
        public void inserirFuncionaario(Funcionario_DTO funcionario)
        {
            int Tipo = 2;
            string retorno;  
            try 
            {
                String sql = "CALL proc_CadFuncionario(@nome,@Nascimento,@Sexo,@CPF,@Telefone,@Celular,@Cargo, @Email,@Senha,@Tipo);SELECT LAST_INSERT_ID();";

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
                
                retorno = Convert.ToString(cmd.ExecuteScalar());

                String sqlEnd = "CALL proc_CadEnderecoFunc(@IdFunc, @TipoEndereco, @Logradouro, @Numero, @Complemento, @Bairro, @CEP, @Cidade, @Estado, @UF);";

                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd1 = new MySqlCommand(sqlEnd, con);
                cmd1.Parameters.AddWithValue("@IdFunc", retorno);
                cmd1.Parameters.AddWithValue("@TipoEndereco", funcionario.TipoEndereco);
                cmd1.Parameters.AddWithValue("@Logradouro", funcionario.logradouro);
                cmd1.Parameters.AddWithValue("@Numero", funcionario.numero);
                cmd1.Parameters.AddWithValue("@Complemento", funcionario.complemento);
                cmd1.Parameters.AddWithValue("@Bairro", funcionario.bairro);
                cmd1.Parameters.AddWithValue("@CEP", funcionario.CEP);
                cmd1.Parameters.AddWithValue("@Cidade", funcionario.cidade);
                cmd1.Parameters.AddWithValue("@Estado", funcionario.estado);
                cmd1.Parameters.AddWithValue("@UF", funcionario.UF);
                


                con.Open();
                cmd1.ExecuteNonQuery();
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
                // db.Dispose();
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
                    using (MySqlCommand command = new MySqlCommand("CALL SelecionarFuncionario( )", conn))
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

        // Selecionar Lista Funcionario
        public List<Funcionario_DTO> selectListFuncionarioDetalhes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    using (MySqlCommand command = new MySqlCommand("CALL proc_SelecionarFuncionarioDetalhes( )", conn))
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

                                funcionario.TipoEndereco = dr["TipoEndereco"].ToString();
                                funcionario.logradouro = dr["Logradouro"].ToString();
                                funcionario.numero = Convert.ToInt32(dr["Numero"]);
                                funcionario.complemento = dr["Complemento"].ToString();
                                funcionario.bairro = dr["Bairro"].ToString();
                                funcionario.CEP = dr["CEP"].ToString();
                                funcionario.cidade = dr["Cidade"].ToString();
                                funcionario.estado = dr["Estado"].ToString();
                                funcionario.UF = dr["UF"].ToString();

                                listaFuncionario.Add(funcionario);
                            }
                        }
                        return listaFuncionario;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar funcionario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar funcionario" + ex.Message);
            }
        }
        // UPDATE FUNCIONARIO
        public void updateFuncionario(Funcionario_DTO funcionario)
        {
            try
            {
                //String sql = " update tbfuncionario set Nome = @Nome, Nascimento = @Nascimento, Sexo = @Sexo, CPF = @CPF, " +
                //"Telefone = @Telefone, Cargo = @Cargo, Celular = @Celular, Email = @Email, Senha = @Senha  where IdFunc = @IdFunc;";

                String sql = " CALL proc_UpdateFuncionario(@IdFunc, @Nome, @CPF, @Sexo, @Telefone, @Celular,@Nascimento,  @Cargo, " +
                             " @Email, @Senha); ";

                //Alter Funcionario
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@Celular", funcionario.Celular);
                cmd.Parameters.AddWithValue("@Nascimento", funcionario.Nascimento); 
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@Email", funcionario.Email);
                cmd.Parameters.AddWithValue("@Senha", funcionario.Senha);
                cmd.Parameters.AddWithValue("@IdFunc", funcionario.IdFunc);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do Funcionario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do Funcionario" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // DELETAR FUNCIONARIO
        public void deleteFuncionario(int id)
        {
            try
            {
                String sql1 = "CALL  proc_DeleteEndereco(@IdFunc); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@IdFunc", id);
                con.Open();
                cmd1.ExecuteNonQuery();


                String sql = "CALL  proc_DeleteEnderecoFunc(@IdFunc); ";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdFunc", id);
                con.Open();
                cmd.ExecuteNonQuery();

                

            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao deletar funcionario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao deletar funcionario" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}