using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DAO
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;password=root;database=Livraria01");
        public static string msg;

        public MySqlConnection MyConectarBD() //Método: MyConectarBD()
        {

            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
        public string RetornaDado(string StrQuery)
        {
            var vComando = new MySqlCommand(StrQuery, cn);
            return vComando.ExecuteScalar().ToString();
        }

        public MySqlConnection MyDesConectarBD()  //Método: MyDesConectarBD()
        {

            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}