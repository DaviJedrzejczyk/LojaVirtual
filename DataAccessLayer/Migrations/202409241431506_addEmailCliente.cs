namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Cli_Email", c => c.String(maxLength: 50));
            CreateIndex("dbo.Clientes", "Cli_Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "Cli_Email" });
            DropColumn("dbo.Clientes", "Cli_Email");
        }
    }
}
