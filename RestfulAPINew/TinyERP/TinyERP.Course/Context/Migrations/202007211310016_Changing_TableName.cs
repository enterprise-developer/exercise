﻿namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changing_TableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseAggregateRoots", newName: "Courses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Courses", newName: "CourseAggregateRoots");
        }
    }
}
