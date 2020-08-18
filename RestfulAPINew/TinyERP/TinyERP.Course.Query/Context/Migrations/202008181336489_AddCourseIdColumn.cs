namespace TinyERP.Course.Query.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseIdColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDetails", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseDetails", "CourseId");
        }
    }
}
