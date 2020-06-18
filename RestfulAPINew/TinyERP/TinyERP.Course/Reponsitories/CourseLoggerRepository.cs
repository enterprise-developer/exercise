using TinyERP.Common;
using TinyERP.Common.Repositories;
using TinyERP.Course.Context;

namespace TinyERP.Course.Reponsitories
{
    internal class CourseLoggerRepository : BaseRepository<TinyERP.Course.Entities.CourseLogger>, ICourseLoggerRepository
    {
        public CourseLoggerRepository(CourseContext context, ContextMode mode = ContextMode.Write) : base(context, mode)
        {
        }
        public CourseLoggerRepository() : base()
        {
        }
    }
}
