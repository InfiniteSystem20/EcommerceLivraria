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

        //public void TestarUsuario(Cliente_DTO user)
        //{
            
        //    /*MySqlCommand cmd = new MySqlCommand("select * from tbCliente where Email = @Email and Senha = @Senha ", con.MyConectarBD());*/
        //    MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblogin as t1 " +
        //                                         " LEFT JOIN tbCliente as t3 on t1.IdCli = t3.IdCli " +
        //                                         " LEFT JOIN tbfuncionario as t2 on t1.IdFunc = t2.IdFunc " +
        //                                         " where t3.Email = @Email and t3.Senha = @Senha or " +
        //                                         " t2.Email = @Email and t2.Senha = @Senha ", con.MyConectarBD());




        //    cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
        //    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.Senha;

        //    MySqlDataReader leitor;

        //    leitor = cmd.ExecuteReader();

        //    if (leitor.HasRows)
        //    {
        //        while (leitor.Read())
        //        {
        //            user.Nome = Convert.ToString(leitor["Nome"]);
        //            user.Email = Convert.ToString(leitor["Email"]);
        //            user.Senha = Convert.ToString(leitor["Senha"]);
        //            user.IdCli = Convert.ToInt32(leitor["IdCli"]);
        //            user.Tipo = Convert.ToString(leitor["Tipo"]);
        //        }
        //    }

        //    else
        //    {
        //        user.Nome = null;
        //        user.Email = null;
        //        user.Senha = null;
        //        user.Tipo = null;
        //    }
        //    con.MyDesConectarBD();
        //}
        
        public void TestarUsuarioGeral(Login user)
        {          

            /*MySqlCommand cmd = new MySqlCommand("select * from tbCliente where Email = @Email and Senha = @Senha ", con.MyConectarBD());*/
            MySqlCommand cmd = new MySqlCommand(" SELECT t1.IdCli, t1.IdFunc, t3.Nome as NomeCli, t2.Nome as NomeFunc, t3.Email as EmailCli," +
                                                 " t2.Email as EmailFunc, t2.Senha as SenhaFunc, t3.Senha as SenhaCli, t1.Tipo " +
                                                 " FROM tblogin as t1 " +
                                                 " LEFT JOIN tbCliente as t3 on t1.IdCli = t3.IdCli " +
                                                 " LEFT JOIN tbfuncionario as t2 on t1.IdFunc = t2.IdFunc " +
                                                 " where t3.Email = @Email and t3.Senha = @Senha or " +
                                                 " t2.Email = @Email and t2.Senha = @Senha ", con.MyConectarBD());

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