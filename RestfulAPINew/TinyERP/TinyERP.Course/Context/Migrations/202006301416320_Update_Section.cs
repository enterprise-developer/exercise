namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Section : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Description");
        }
    }
}
