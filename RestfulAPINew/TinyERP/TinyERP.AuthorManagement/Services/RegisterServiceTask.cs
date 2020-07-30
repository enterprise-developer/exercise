using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.AuthorManagement.Services
{
    public class RegisterServiceTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<IAuthorService, AuthorService>();
        }
    }
}
