using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Query.Reponsitories;

namespace TinyERP.Course.Query.Responsitories
{
    public class RegisterRepositoryTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<ICourseQueryRepository, CourseQueryRepository>();
        }
    }
}
