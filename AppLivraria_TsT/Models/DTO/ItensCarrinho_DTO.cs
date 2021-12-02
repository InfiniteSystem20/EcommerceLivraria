using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class ItensCarrinho_DTO
    {
        [Key]
        public Guid IdItensCar { get; set; }
        
        public string IdPedido { get; set; }

        public string IdProd { get; set; }

        public string Produto { get; set; }
        public string Imagem { get; set; }
        
        public decimal valorUnit { get; set; }

        public decimal Qtd { get; set; }

        public string IdCli { get; set; }
        public string DtPedido { get; set; }
        public string HoraPedido { get; set; }
        public decimal valorParcial { get; set; }

        [Display(Name = "Valor Total", Description = "Valor Total")]

        public decimal ValorTotal { get; set; }

        //public List<ItensCarrinho_DTO> ItensPedido = new List<ItensCarrinho_DTO>();
    }
}