using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("ProdutoPedidos")]
    public class ProdutoPedido
    {
        public long ProdutoId { get; set; }
        public long PedidoId { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }

        public ProdutoPedido(long prodId, long pedId)
        {
            this.ProdutoId = prodId;
            this.PedidoId = pedId;
        }

        public ProdutoPedido()
        {
            
        }
    }
}
