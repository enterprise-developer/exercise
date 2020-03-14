using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.Course.Services
{
    public class RegistrationServicesTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<ICourseService, CourseService>();
        }
    }
}
