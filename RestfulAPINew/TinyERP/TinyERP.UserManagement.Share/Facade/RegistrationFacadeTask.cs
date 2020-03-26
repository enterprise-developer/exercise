using System.Configuration;
using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Share.Facade
{
    internal class RegistrationFacadeTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {            
            ConfigurationApp configurationApp = ConfigurationManager.GetSection("appConfig") as ConfigurationApp;
            int mode = configurationApp.UserManagement.Mode;
            if (mode == UserManagementConfiguration.Remote)
            {
                IoC.RegisterTransient<IUserFacade, RemoteUserFacade>();
            }
        }
    }
}
