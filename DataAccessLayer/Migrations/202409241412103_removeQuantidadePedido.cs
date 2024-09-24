namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeQuantidadePedido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidos", "Ped_Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "Ped_Quantidade", c => c.Int(nullable: false));
        }
    }
}
