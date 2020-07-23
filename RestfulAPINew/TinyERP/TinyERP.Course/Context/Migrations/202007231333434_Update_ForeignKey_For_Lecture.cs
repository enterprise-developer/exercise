namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ForeignKey_For_Lecture : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Lectures", "SectionId");
            AddForeignKey("dbo.Lectures", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "SectionId", "dbo.Sections");
            DropIndex("dbo.Lectures", new[] { "SectionId" });
        }
    }
}
