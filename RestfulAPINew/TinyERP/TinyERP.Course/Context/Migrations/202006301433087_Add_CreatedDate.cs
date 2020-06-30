namespace TinyERP.Course.Context.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Add_CreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "CreatedDate");
        }
    }
}
