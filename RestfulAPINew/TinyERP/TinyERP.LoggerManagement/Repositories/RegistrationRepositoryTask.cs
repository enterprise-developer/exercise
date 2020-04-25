using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.LoggerManagement.Repositories
{
    public class RegistrationRepositoryTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<ILoggerRepository, LoggerRepository>();
        }
    }
}
