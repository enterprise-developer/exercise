using TinyERP.Common;
using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.UserManagement.Facade;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.UserManagement.Tasks
{
    public class RegisterFacadeTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            ModuleDeploymentMode mode = ConfigurationApp.Instance.UserManagement.Mode;
            if (mode == ModuleDeploymentMode.InApp)
            {
                IoC.RegisterTransient<IUserFacade, UserFacade>();
            }
        }
    }
}
