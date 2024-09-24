using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public long Ped_Id { get; set; }
        public long Cli_Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Ped_Data { get; set; }
        public double Ped_Valor { get; set; }
        public int Ped_Quantidade { get; set; }
        public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; }
        public EStatusPedido Ped_Status { get; set; }

        public Pedido()
        {
               
        }

        public Pedido(PedidoDTO pedidoDTO)
        {
            this.Cli_Id = pedidoDTO.Cli_Id;
            this.Ped_Data = pedidoDTO.Ped_Data;
            this.Ped_Valor = pedidoDTO.Ped_Valor;
            this.Ped_Quantidade = pedidoDTO.Ped_Quantidade;
            this.Ped_Status = pedidoDTO.EStatusPedido;
        }
    }
}
