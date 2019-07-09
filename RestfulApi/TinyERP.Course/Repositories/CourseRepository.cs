
namespace TinyERP.Course.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.UoW;
    using TinyERP.Course.Data.Repositories;

    internal class CourseRepository : BaseRepository<Entity.Course>, ICourseRepository
    {
        public CourseRepository() : base()
        {

        }

        public CourseRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context)
        {

        }
        public IList<Entity.Course> GetCourses()
        {
            return this.DbSet.AsQueryable().ToList();
        }
    }
}
