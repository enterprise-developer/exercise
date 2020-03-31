using System.Configuration;
using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.UserManagement.Facade;
using TinyERP.UserManagement.Share;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.UserManagement.Tasks
{
    public class RegisterFacadeTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            int mode = ConfigurationApp.Instance.UserManagement.Mode;
            if (mode == UserManagementConfiguration.InApp)
            {
                IoC.RegisterTransient<IUserFacade, UserFacade>();
            }
        }
    }
}
