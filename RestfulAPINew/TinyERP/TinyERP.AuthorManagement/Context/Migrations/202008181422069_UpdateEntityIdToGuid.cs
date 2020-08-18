namespace TinyERP.AuthorManagement.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntityIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authors", "Id");
        }
    }
}
