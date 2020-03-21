using System.Data.Entity;

namespace TinyERP.Course.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext():base("CourseContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseContext>());
        }

        public DbSet<TinyERP.Course.Entities.Course> Courses { get; set; }
    }
}
