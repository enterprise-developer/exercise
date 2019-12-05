namespace TinyERP.UserMangement.Share.Task
{
    using System.Configuration;
    using TinyERP.Common;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Tasks;
    using TinyERP.UserManagement.Share.Facade;
    using TinyERP.UserMangement.Repository;
    using TinyERP.UserMangement.Service;
    using TinyERP.UserMangement.Share.Facade;

    public class BootStrapper : BaseTask, IBootStrapper
    {
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<IUserService, UserService>();
            IoC.RegisterAsTransient<IUserRepository, UserRepository>();

            IntegrationModeType mode = TinyERP.Common.Config.Configuration.Instance.UserManagement.IntegrationMode;
            if (mode != IntegrationModeType.Remote)
            {
                IoC.RegisterAsSingleton<IUserManagementFacade, UserManagementFacade>();
            }


        }
    }
}