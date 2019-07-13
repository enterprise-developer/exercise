using System.Data.Entity;
using TinyERP.Common.Common.Data;
using TinyERP.Common.Common.Helper;

namespace TinyERP.Course.Context
{
    public class CourseDbContext : BaseDbContext, ICourseDbContext
    {
        public CourseDbContext() : base(DatabaseConnectionHelper.GetConnection<ICourseDbContext>().ToString())
        {
            //Database.SetInitializer<CourseDbContext>(null);

        }

        public IDbSet<Entity.Course> Courses { get; set; }
        public IDbSet<Entity.Student> Students { get; set; }
    }
}
