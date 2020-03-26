using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Repositories
{
    public class RegistrationRepositoriesTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IUserRepository, UserRepository>();
        }
    }
}
