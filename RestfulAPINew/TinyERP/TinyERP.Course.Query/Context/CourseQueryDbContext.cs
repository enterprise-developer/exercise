using System.Data.Entity;
using TinyERP.Common.Contexts;
using TinyERP.Common.Helpers;
using TinyERP.Course.Query.Entities;

namespace TinyERP.Course.Query.Context
{
    public class CourseQueryDbContext : DbContext, IBaseContext
    {
        public CourseQueryDbContext() : base(DatabaseConnectionHelper.GetConnection<CourseQueryDbContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourseQueryDbContext>());
        }
        public DbSet<CourseDetail> CourseDetails { get; set; }
    }
}
