using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class Categoria_DTO
    {
        [Key]
        [Display(Name = "Código ", Description = "Codigo.")]
        public int IdCat { get; set; }

        [Display(Name = "Categoria", Description = "Categoria")]
        [Required(ErrorMessage = "O Categoria é obrigatório.")]
        public string Nome { get; set; }

    }
}