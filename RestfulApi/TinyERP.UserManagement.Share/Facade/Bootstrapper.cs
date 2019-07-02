using System.Configuration;
using TinyERP.Common;
using TinyERP.Common.Common.IoC;
using TinyERP.Common.Common.Task;

namespace TinyERP.UserManagement.Share.Facade
{
    public class Bootstrapper : IBootStrapper
    {
        public void Execute()
        {
            var mode = TinyERP.Common.Config.Configuration.Instance.UserManagement.IntegrationMode;//ConfigurationManager.AppSettings["UserManagement:IntergrationMode"];
            if (mode == IntegrationModeType.Remote)
            {
                IoC.RegisterAsSingleton<IUserManagementFacade, RemoteUserManagementFacade>();
            }
        }
    }
}
