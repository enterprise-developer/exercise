using TinyERP.Common;
using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Share.Facade
{
    internal class RegistrationFacadeTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            ModuleDeploymentMode mode = ConfigurationApp.Instance.UserManagement.Mode;
            if (mode == ModuleDeploymentMode.Remote)
            {
                IoC.RegisterTransient<IUserFacade, RemoteUserFacade>();
            }
        }
    }
}
