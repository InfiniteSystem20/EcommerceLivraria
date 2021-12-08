using AppLivraria_TsT.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class AcoesLogin
    {
        Conexao con = new Conexao();
        
        public void TestarUsuarioGeral(Login user)
        {

            MySqlCommand cmd = new MySqlCommand("Call proc_SelecionarLogin(@Email, @Senha) ", con.MyConectarBD());            

            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.Senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.Nome  = Convert.ToString(leitor["NomeCli"]);
                    user.Email = Convert.ToString(leitor["EmailCli"]);
                    user.Senha = Convert.ToString(leitor["SenhaCli"]);                    
                    user.Tipo = Convert.ToString(leitor["Tipo"]);
                   
                }
                if(user.Tipo == "1") { 
                user.IdCli = Convert.ToInt32(leitor["IdCli"]);
                }
                if (user.Tipo == "2")
                {
                    user.IdFunc = Convert.ToInt32(leitor["IdFunc"]);
                    user.Nome = Convert.ToString(leitor["NomeFunc"]);
                    user.Email = Convert.ToString(leitor["EmailFunc"]);
                    user.Senha = Convert.ToString(leitor["SenhaFunc"]);
                }
                if (user.Tipo == "3")
                {
                    user.IdFunc = Convert.ToInt32(leitor["IdFunc"]);
                    user.Nome = Convert.ToString(leitor["NomeFunc"]);
                    user.Email = Convert.ToString(leitor["EmailFunc"]);
                    user.Senha = Convert.ToString(leitor["SenhaFunc"]);
                }
            }
            else
            {
                user.Nome = null;
                user.Email = null;
                user.Senha = null;
                user.Tipo = null;
            }
            con.MyDesConectarBD();
        }
    }
}