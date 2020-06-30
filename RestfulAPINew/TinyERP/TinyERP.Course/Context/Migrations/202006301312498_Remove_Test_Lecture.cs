namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Test_Lecture : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lectures", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lectures", "Test", c => c.String());
        }
    }
}
