namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Cli_Id = c.Long(nullable: false, identity: true),
                        Cli_Nome = c.String(),
                        Cli_DataNascimento = c.DateTime(nullable: false),
                        Cli_Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cli_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
