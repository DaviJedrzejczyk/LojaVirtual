namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoQuantidadeProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "Ped_Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedidos", "Ped_Valor", c => c.Double(nullable: false));
            AddColumn("dbo.Produtos", "Prod_Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Pedidos", "Data");
            DropColumn("dbo.Pedidos", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "Valor", c => c.Double(nullable: false));
            AddColumn("dbo.Pedidos", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Produtos", "Prod_Quantidade");
            DropColumn("dbo.Pedidos", "Ped_Valor");
            DropColumn("dbo.Pedidos", "Ped_Data");
        }
    }
}
