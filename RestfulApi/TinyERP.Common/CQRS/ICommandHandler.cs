namespace TinyERP.Common.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand: ICommand
    {
        void Handle(TCommand comand);
    }
}
