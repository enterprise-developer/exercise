using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.UserManagement.Repositories;

namespace TinyERP.UserManagement.Tasks
{
    public class RegistrationRepositoriesTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IUserRepository, UserRepository>();
        }
    }
}
