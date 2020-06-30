namespace TinyERP.Course.Context.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Update_Lecture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lectures", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lectures", "Test");
        }
    }
}
