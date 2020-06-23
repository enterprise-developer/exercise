using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Repositories
{
    internal class RegistrationRepositoriesTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<ICourseRepository, CourseRepository>();
            IoC.RegisterTransient<ICourseLoggerRepository, CourseLoggerRepository>();
            IoC.RegisterTransient<ISectionRepository, SectionRepository>();
            IoC.RegisterTransient<ILectureRepository, LectureRepository>();
        }
    }
}
