using System.Data.Entity;

namespace TinyERP.Course.Context
{
    public class CourseDbContext : DbContext, ICourseDbContext
    {
        public CourseDbContext() : base("CourseDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseDbContext>());
        }

        public IDbSet<Entity.Course> Courses { get; set; }
    }
}
