namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditClienteMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cli_DataNascimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Cli_DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
