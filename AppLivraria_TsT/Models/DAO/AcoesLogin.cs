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

        public void TestarUsuario(Cliente_DTO user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCliente where Email = @Email and Senha = @Senha ", con.MyConectarBD());

            
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.Senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.Nome = Convert.ToString(leitor["Nome"]);
                    user.Email = Convert.ToString(leitor["Email"]);
                    user.Senha = Convert.ToString(leitor["Senha"]);
                    user.Tipo = Convert.ToString(leitor["Tipo"]);
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