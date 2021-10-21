//using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppLivraria_TsT.Models.DTO
{
    public class Cliente_DTO
    {
        /* PK */
        [Display(Name = "Código", Description = "Código.")]
        public int IdCli { get; set; }

        [Display(Name = "Nome", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string Nascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string Sexo { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string CPF { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O senha é obrigatorio")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }

        public string Tipo { get; set; }

        //ENDEREÇO FUNCIONARIO
        [Display(Name = "Logradouro ", Description = "rua/avenida/praça")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        //           "Números e caracteres especiais não são permitidos no nome.")]
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
