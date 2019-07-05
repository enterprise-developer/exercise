
namespace TinyERP.Course.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Data;
    using TinyERP.Course.Data.Repositories;

    internal class CourseRepository : BaseRepository<Entity.Course>, ICourseRepository
    {   public IList<Entity.Course> GetCourses()
        {
            return this.DbSet.ToList();
        }
    }
}
