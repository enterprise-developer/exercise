
namespace TinyERP.Course.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Common.Data;
    using TinyERP.Common.Data;
    using TinyERP.Course.Data.Repositories;

    internal class CourseRepository : BaseRepository<Entity.Course>, ICourseRepository
    {
        public CourseRepository() : base()
        {

        }

        public CourseRepository(IDbContext dbContext) : base(dbContext)
        {

        }
        public IList<Entity.Course> GetCourses()
        {
            return this.DbSet.ToList();
        }
    }
}
