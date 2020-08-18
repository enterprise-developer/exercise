using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TinyERP.Common.Databases;

namespace TinyERP.UserManagement.Context.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TinyERP.UserManagement.Context.UserDbContext>, IDbMigratorConfiguration
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TinyERP.UserManagement.Context.UserDbContext";
            MigrationsDirectory = @"Context\Migrations";
        }

        protected override void Seed(TinyERP.UserManagement.Context.UserDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
