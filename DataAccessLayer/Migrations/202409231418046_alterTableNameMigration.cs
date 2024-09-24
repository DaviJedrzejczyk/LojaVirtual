namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTableNameMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pedidoes", newName: "Pedidos");
            RenameTable(name: "dbo.ProdutoPedidoes", newName: "ProdutoPedidos");
            RenameTable(name: "dbo.Produtoes", newName: "Produtos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Produtos", newName: "Produtoes");
            RenameTable(name: "dbo.ProdutoPedidos", newName: "ProdutoPedidoes");
            RenameTable(name: "dbo.Pedidos", newName: "Pedidoes");
        }
    }
}
