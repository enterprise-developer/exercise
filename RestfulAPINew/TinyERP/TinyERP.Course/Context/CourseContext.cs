using System.Data.Entity;
using TinyERP.Common.Contexts;
using TinyERP.Common.Helpers;
using TinyERP.Course.Entities;

namespace TinyERP.Course.Context
{
    public class CourseContext : DbContext, IBaseContext
    {
        public CourseContext() : base(DatabaseConnectionHelper.GetConnection<CourseContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseContext>());
        }

        public DbSet<TinyERP.Course.Entities.Course> Courses { get; set; }
        public DbSet<CourseLogger> CourseLoggers { get; set; }
        public DbSet<Entities.Section> Sections { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
    }
}
