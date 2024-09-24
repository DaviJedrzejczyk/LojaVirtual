namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "EStatusPedido", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidos", "EStatusPedido");
        }
    }
}
