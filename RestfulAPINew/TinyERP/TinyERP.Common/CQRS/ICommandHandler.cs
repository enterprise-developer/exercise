namespace TinyERP.Common.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : IBaseCommand
    {
        void Handle(TCommand command);
    }
}
