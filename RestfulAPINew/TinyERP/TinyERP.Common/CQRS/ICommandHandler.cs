namespace TinyERP.Common.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : IBaseCommand
    {
        void Handle(TCommand command);
    }
    public interface ICommandHandler<TCommand, TResponse> where TCommand : IBaseCommand where TResponse : class, IBaseResponse
    {
        TResponse Handle(TCommand command);
    }
}
