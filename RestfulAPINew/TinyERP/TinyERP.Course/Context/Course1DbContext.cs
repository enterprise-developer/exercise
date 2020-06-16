using System.Data.Entity;
using TinyERP.Common.Contexts;

namespace TinyERP.Course.Context
{
     class Course1DbContext : DbContext, IBaseContext
    {
        public Course1DbContext():base("connectionStrings")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Course1DbContext>());
        }
        public DbSet<Course.Entities.Course> Courses { get; set; }
    }
}
