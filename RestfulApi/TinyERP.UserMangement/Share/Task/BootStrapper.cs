namespace TinyERP.UserMangement.Share.Task
{
    using System.Configuration;
    using TinyERP.Common;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.UserManagement.Share.Facade;
    using TinyERP.UserMangement.Service;
    using TinyERP.UserMangement.Share.Facade;

    public class BootStrapper : IBootStrapper
    {
        public void Execute()
        {
            IoC.RegisterAsSingleton<IUserService, UserService>();


            IntegrationModeType mode = TinyERP.Common.Config.Configuration.Instance.UserManagement.IntegrationMode;
            if (mode != IntegrationModeType.Remote)
            {
                IoC.RegisterAsSingleton<IUserManagementFacade, UserManagementFacade>();
            }


        }
    }
}