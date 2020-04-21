using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.Common.Logs
{
    internal class RegistrationLoggerTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            if (ConfigurationApp.Instance.Logger.Type == ApplicationLoggerType.File)
            {
                IoC.RegisterSingleton<ILogger, FileLogger>();
            }
        }
    }
}
