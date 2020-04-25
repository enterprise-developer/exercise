using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.LoggerManagement.Service
{
    public class RegistrationServiceTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<ILoggerService, LoggerService>();
        }
    }
}
