namespace TinyERP.Course.Query.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DenormalizedId_For_CourseDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDetails", "AggregateId", c => c.Guid(nullable: false));
            DropColumn("dbo.CourseDetails", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseDetails", "CourseId", c => c.Guid(nullable: false));
            DropColumn("dbo.CourseDetails", "AggregateId");
        }
    }
}
