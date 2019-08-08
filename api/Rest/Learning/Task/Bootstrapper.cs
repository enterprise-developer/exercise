using Learning.Repositories;
using Learning.Services;
using TinyERP.Common.IoC;
using TinyERP.Common.Tasks;

namespace Learning.Task
{
    public class Bootstrapper : IBootstrapper
    {
        public void Execute()
        {
            IoC.Container.RegisterAsSingleton<IStudentService, StudentService>();
            IoC.Container.RegisterAsSingleton<IStudentRepository, StudentRepository>();
        }
    }
}
