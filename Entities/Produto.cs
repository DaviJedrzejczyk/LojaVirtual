using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public long Prod_ID { get; set; }
        public string Prod_Nome { get; set; }
        public double Prod_Preco { get; set; }
        public int Prod_Quantidade { get; set; }
        public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; }

        public Produto()
        {
            
        }

        public Produto(long id, string nome, double preco, int prod_Quantidade)
        {
            this.Prod_Nome = nome;
            this.Prod_Preco = preco;
            this.Prod_ID = id;
            this.Prod_Quantidade = prod_Quantidade;
        }
    }
}
