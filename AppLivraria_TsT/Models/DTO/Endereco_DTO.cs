using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class Endereco_DTO
    {
        [Display(Name = "Código ", Description = "Código")]
        public int IdEnd { get; set; }

        public string IdCli { get; set; }
        public string IdFunc { get; set; }

        //ENDEREÇO FUNCIONARIO
        [Display(Name = "Logradouro ", Description = "rua/avenida/praça")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        // "Números e caracteres especiais não são permitidos no nome.")]
        public string logradouro { get; set; }

        [Display(Name = "Número ", Description = "Número")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor coloque numero valido")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public int numero { get; set; }

        [Display(Name = "Complemento ", Description = "casa/apto/viela")]
        // [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string complemento { get; set; }

        [Display(Name = "Bairro ", Description = "Bairro")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string bairro { get; set; }

        [Display(Name = "CEP ", Description = "CEP")]
        ///[Range(0, int.MaxValue, ErrorMessage = "Por favor coloque numero valido")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string CEP { get; set; }

        [Display(Name = "Cidade ", Description = "Cidade")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
        public string cidade { get; set; }

        [Display(Name = "Estado ", Description = "Estado")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //          "Números e caracteres especiais não são permitidos no nome.")]
        public string estado { get; set; }

        [Display(Name = "UF ", Description = "UF")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
                  "Números e caracteres especiais não são permitidos no nome.")]
        public string UF { get; set; }

        [Display(Name = "Cobraça/Entrega", Description = "Tipo Endereço")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string TipoEndereco { get; set; }
    }
}