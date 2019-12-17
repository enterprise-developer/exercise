using System.Configuration;
using TinyERP.Common;
using TinyERP.Common.Common.IoC;
using TinyERP.Common.Common.Task;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Share.Facade
{
    public class Bootstrapper : BaseTask, IBootstrapper
    {
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            var mode = TinyERP.Common.Config.Configuration.Instance.UserManagement.IntegrationMode;//ConfigurationManager.AppSettings["UserManagement:IntergrationMode"];
            if (mode == IntegrationModeType.Remote)
            {
                IoC.RegisterAsSingleton<IUserManagementFacade, RemoteUserManagementFacade>();
            }
        }
    }
}
