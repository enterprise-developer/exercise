using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Services;

namespace TinyERP.Course.Task
{
    public class ApplicationStartTask : IApplicationStartTask
    {
        public void Execute()
        {
            IoC.RegisterTransient<ICourseService, CourseService>();
        }
    }
}
