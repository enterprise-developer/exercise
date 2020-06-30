namespace TinyERP.Course.Context.Migrations
{
    using System.Data.Entity.Migrations;
    using TinyERP.Common.Databases;

    public class Configuration : DbMigrationsConfiguration<TinyERP.Course.Context.CourseContext>, IDbMigratorConfiguration
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TinyERP.Course.Context.CourseContext";
            MigrationsDirectory = @"Context\Migrations";
        }

        protected override void Seed(TinyERP.Course.Context.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
