using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Share.Facade
{
    internal class RegistrationFacadeTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            int mode = UserManagementConfiguration.Remote;
            if (mode == UserManagementConfiguration.Remote)
            {
                IoC.RegisterTransient<IUserFacade, RemoteUserFacade>();
            }
        }
    }
}
