using System.Data.Entity;
using TinyERP.Common.Helpers;

namespace TinyERP.Course.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base(DatabaseConnectionHelper.GetConnection<CourseContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseContext>());
        }

        public DbSet<TinyERP.Course.Entities.Course> Courses { get; set; }
    }
}
