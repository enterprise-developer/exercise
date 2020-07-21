namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ForeignKey_For_Section : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Sections", "CourseId");
            AddForeignKey("dbo.Sections", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "CourseId", "dbo.Courses");
            DropIndex("dbo.Sections", new[] { "CourseId" });
        }
    }
}
