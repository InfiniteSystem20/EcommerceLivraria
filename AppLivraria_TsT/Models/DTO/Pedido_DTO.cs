using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class Pedido_DTO
    {
        [Display(Name = "Código", Description = "Código")]
        public string IdPedido { get; set; }

        [Display(Name = "Data", Description = "Data")]
        public string DtPedido { get; set; }
        
        public string IdCli { get; set; }

        [Display(Name = "Hora", Description = "Hora")]
        public string HoraPedido { get; set; }
        [Display(Name = "Total", Description = "Total")]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Status", Description = "Status")]
        public string StatusPedido { get; set; }

        public List<ItensCarrinho_DTO> ItensPedido = new List<ItensCarrinho_DTO>();

        //itens do carrinho
        public string IdProd { get; set; }
        public string Produto { get; set; }
        public string Imagem { get; set; }

        public decimal valorUnit { get; set; }

        public decimal Qtd { get; set; }

        public decimal valorParcial { get; set; }

        //Dados do cliente
        [Display(Name = "Nome", Description = "Nome e Sobrenome.")]        
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string CPF { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
    }
}