using System.Data.Entity;
using TinyERP.Common.Common.Data;

namespace TinyERP.Course.Context
{
    public class CourseDbContext : BaseDbContext, ICourseDbContext
    {
        public CourseDbContext() : base("CourseDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseDbContext>());
        }

        public IDbSet<Entity.Course> Courses { get; set; }
        public IDbSet<Entity.Student> Students { get; set; }
    }
}
