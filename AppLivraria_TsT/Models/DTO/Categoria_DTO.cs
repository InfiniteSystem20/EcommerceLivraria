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

        public int IdProd { get; set; }
        [Display(Name = "Categoria", Description = "Categoria")]
       
        [Required(ErrorMessage = "O Categoria é obrigatório.")]
        public string Nome { get; set; }


        [Display(Name = "ISBN", Description = "ISBN.")]
        public string ISBN { get; set; }

        [Display(Name = "Nome", Description = "Nome.")]
        // [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string NomeProd { get; set; }

        [Display(Name = "Descrição", Description = "Descrição.")]
        //[Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Preço", Description = "Preço.")]
        // [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public decimal PrecoUni { get; set; }

        [Display(Name = "Estoque", Description = "Estoque.")]
        //[Required(ErrorMessage = "O nome completo é obrigatório.")]
        public int Estoque { get; set; }

        [Display(Name = "Autor", Description = "Autor.")]
        public string Autor { get; set; }

        [Display(Name = "Categiria", Description = "Categiria.")]
        public string Categiria { get; set; }

        [Display(Name = "Imagem", Description = "Imagem.")]
        //  [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Imagem { get; set; }

    }
}