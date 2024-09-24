namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusPedido1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "Ped_Status", c => c.Int(nullable: false));
            DropColumn("dbo.Pedidos", "EStatusPedido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "EStatusPedido", c => c.Int(nullable: false));
            DropColumn("dbo.Pedidos", "Ped_Status");
        }
    }
}
