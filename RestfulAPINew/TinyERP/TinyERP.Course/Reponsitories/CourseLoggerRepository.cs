using TinyERP.Course.Context;
using TinyERP.Course.Entities;

namespace TinyERP.Course.Reponsitories
{
    internal class CourseLoggerRepository : ICourseLoggerRepository
    {
        private CourseContext context;
        public CourseLoggerRepository(CourseContext context)
        {
            this.context = context;
        }
        public CourseLoggerRepository()
        {
            this.context = new CourseContext();
        }
        public void Create(CourseLogger courseLogger)
        {
            this.context.CourseLoggers.Add(courseLogger);
        }
    }
}
