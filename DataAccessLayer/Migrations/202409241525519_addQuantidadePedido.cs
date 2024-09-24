namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuantidadePedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "Ped_Quantidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidos", "Ped_Quantidade");
        }
    }
}
