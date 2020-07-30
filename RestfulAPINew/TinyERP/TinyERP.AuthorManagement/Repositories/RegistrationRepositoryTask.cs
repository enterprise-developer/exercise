using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.AuthorManagement.Repositories
{
    public class RegistrationRepositoryTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<IAuthorRepository, AuthorRepository>();
        }
    }
}
