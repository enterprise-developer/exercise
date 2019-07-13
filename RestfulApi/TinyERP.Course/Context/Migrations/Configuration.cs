namespace TinyERP.Course.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TinyERP.Common.Common.Helper;
    using TinyERP.Course.Share.Task;

    internal sealed class Configuration : DbMigrationsConfiguration<TinyERP.Course.Context.CourseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.MigrationsDirectory = "Context\\Migrations";
        }

        protected override void Seed(TinyERP.Course.Context.CourseDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AssemblyHelper.Execute<ICreateSeedDataCourseDbContext>();
        }
    }
}
