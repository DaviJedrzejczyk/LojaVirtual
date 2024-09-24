namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Ped_Id = c.Long(nullable: false, identity: true),
                        Cli_Id = c.Long(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Ped_Id)
                .ForeignKey("dbo.Clientes", t => t.Cli_Id, cascadeDelete: true)
                .Index(t => t.Cli_Id);
            
            CreateTable(
                "dbo.ProdutoPedidoes",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false),
                        PedidoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutoId, t.PedidoId })
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Prod_ID = c.Long(nullable: false, identity: true),
                        Prod_Nome = c.String(),
                        Prod_Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Prod_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoPedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "Cli_Id", "dbo.Clientes");
            DropIndex("dbo.ProdutoPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.ProdutoPedidoes", new[] { "ProdutoId" });
            DropIndex("dbo.Pedidoes", new[] { "Cli_Id" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.ProdutoPedidoes");
            DropTable("dbo.Pedidoes");
        }
    }
}
