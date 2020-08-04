using TinyERP.AuthorManagement.Commands;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.AuthorManagement.CommandHandlers
{
    public class RegisterCommandHandlersTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<ICommandHandler<UpdateAuthorEmailCommand>, AuthorCommandHandler>();
        }
    }
}
