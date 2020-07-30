namespace TinyERP.AuthorManagement.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Author_Project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Authors");
        }
    }
}
