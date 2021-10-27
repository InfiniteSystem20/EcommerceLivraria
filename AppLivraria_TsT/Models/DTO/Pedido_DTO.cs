using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLivraria_TsT.Models.DTO
{
    public class Pedido_DTO
    {
        public string IdPedido { get; set; }

        public string DtPedido { get; set; }

        public string IdCli { get; set; }

        public string HoraPedido { get; set; }

        public decimal ValorTotal { get; set; }

        public List<ItensCarrinho_DTO> ItensPedido = new List<ItensCarrinho_DTO>();
    }
}