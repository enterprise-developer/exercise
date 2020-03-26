using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Services
{
    internal class RegistrationServiceTasks : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IUserService, UserService>();
        }
    }
}
