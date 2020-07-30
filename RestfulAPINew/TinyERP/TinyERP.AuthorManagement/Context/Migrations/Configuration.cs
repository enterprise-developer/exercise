namespace TinyERP.AuthorManagement.Context.Migrations
{
    using System.Data.Entity.Migrations;
    using TinyERP.Common.Databases;

    internal sealed class Configuration : DbMigrationsConfiguration<TinyERP.AuthorManagement.Context.AuthorDbContext>, IDbMigratorConfiguration
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Context\Migrations";
        }

        protected override void Seed(TinyERP.AuthorManagement.Context.AuthorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
