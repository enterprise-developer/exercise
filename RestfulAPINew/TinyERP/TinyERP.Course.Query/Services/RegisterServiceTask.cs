using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.Course.Query.Services
{
    public class RegisterServiceTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<ICourseQueryService, CourseQueryService>();
        }
    }
}
