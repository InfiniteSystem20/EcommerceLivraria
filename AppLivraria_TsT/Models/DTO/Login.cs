using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class Login
    {
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        public string Senha { get; set; } 
        public int IdCli { get; set; } 
        public int IdFunc { get; set; }       
        public string Tipo { get; set; }

        public string confSenha { get; set; }
    }
}