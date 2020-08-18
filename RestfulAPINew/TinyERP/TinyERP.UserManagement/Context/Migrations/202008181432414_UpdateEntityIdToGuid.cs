﻿namespace TinyERP.UserManagement.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntityIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
