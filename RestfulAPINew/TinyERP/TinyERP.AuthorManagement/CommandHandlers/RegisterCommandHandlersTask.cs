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
            IoC.RegisterSingleton<ICommandHandler<CreateAuthorCommand>, AuthorCommandHandler>("Author.CreateAuthor");
            IoC.RegisterSingleton<ICommandHandler<UpdateAuthorEmailCommand>, AuthorCommandHandler>("Author.UpdateAuthorEmail");
            IoC.RegisterSingleton<ICommandHandler<ActiveAuthorCommand>, AuthorCommandHandler>("Author.ActiveAuthor");
            IoC.RegisterSingleton<ICommandHandler<UpdateAuthorCommand>, AuthorCommandHandler>("Author.UpdateAuthor");
        }
    }
}
