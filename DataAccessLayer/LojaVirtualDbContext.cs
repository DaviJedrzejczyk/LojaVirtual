using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LojaVirtualDbContext : DbContext
    {
        public LojaVirtualDbContext() : base("name=LojaVirtualDbConnectionString")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoPedido>()
           .HasKey(pp => new { pp.ProdutoId, pp.PedidoId });

            modelBuilder.Entity<ProdutoPedido>()
                .HasRequired(pp => pp.Produto)
                .WithMany(p => p.ProdutoPedidos)
                .HasForeignKey(pp => pp.ProdutoId);

            modelBuilder.Entity<ProdutoPedido>()
                .HasRequired(pp => pp.Pedido)
                .WithMany(p => p.ProdutoPedidos)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Cli_Email)
                .IsUnique();
        }
    }
}
