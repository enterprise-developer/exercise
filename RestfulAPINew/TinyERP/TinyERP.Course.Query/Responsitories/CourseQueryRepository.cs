using TinyERP.Common;
using TinyERP.Common.Contexts;
using TinyERP.Common.Repositories;
using TinyERP.Course.Query.Entities;

namespace TinyERP.Course.Query.Reponsitories
{
    public class CourseQueryRepository : BaseQueryRepository<CourseDetail>, ICourseQueryRepository
    {
        //public CourseQueryRepository() : base() { }
        //public CourseQueryRepository(IBaseContext context, ContextMode mode = ContextMode.Write) : base(context, mode) { }
    }
}
