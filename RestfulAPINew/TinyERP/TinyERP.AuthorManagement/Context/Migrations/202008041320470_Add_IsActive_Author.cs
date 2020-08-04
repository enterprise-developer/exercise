namespace TinyERP.AuthorManagement.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsActive_Author : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "IsActive");
        }
    }
}
