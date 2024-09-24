using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PedidoDTO
    {
        public long Ped_Id { get; set; }
        public long Cli_Id { get; set; }
        public string Cli_Email { get; set; }
        public DateTime Ped_Data { get; set; }
        public double Ped_Valor { get; set; }
        public int Ped_Quantidade { get; set; }
        public List<string> ProdutosSelecionados { get; set; }
        public List<int> QuantidadeDosProdutos { get; set; }
        public EStatusPedido EStatusPedido { get; set; }

        public PedidoDTO()
        {
            
        }

        public PedidoDTO(long id, string emailCli, List<string> prodSelecionados, List<int> quantidades)
        {
            this.Ped_Id = id;
            this.Cli_Email = emailCli;
            this.ProdutosSelecionados = prodSelecionados;
            this.QuantidadeDosProdutos = quantidades;
        }
    }
}
