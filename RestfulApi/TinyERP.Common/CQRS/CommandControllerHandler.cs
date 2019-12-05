namespace TinyERP.Common.CQRS
{
    using System.Web.Http;
    using TinyERP.Common.Common.IoC;
    public abstract class CommandControllerHandler: ApiController
    {
        protected void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = IoC.Resolve<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }
    }
}
