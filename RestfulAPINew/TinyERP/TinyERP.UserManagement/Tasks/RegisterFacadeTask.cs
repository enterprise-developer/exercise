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
            IoC.RegisterTransient<IUserFacade, UserFacade>();
        }
    }
}
