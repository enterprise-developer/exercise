namespace TinyERP.Course.Query.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CourseQuery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SectionCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseDetails");
        }
    }
}
