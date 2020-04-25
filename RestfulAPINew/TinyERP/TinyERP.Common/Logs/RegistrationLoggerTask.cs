using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.Common.Logs
{
    internal class RegistrationLoggerTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            switch (ConfigurationApp.Instance.Logger.Type)
            {
                case ApplicationLoggerType.File:
                    IoC.RegisterSingleton<ILogger, FileLogger>();
                    break;
                case ApplicationLoggerType.Api:
                    IoC.RegisterSingleton<ILogger, RestApiLogger>();
                    break;
            }
        }
    }
}
