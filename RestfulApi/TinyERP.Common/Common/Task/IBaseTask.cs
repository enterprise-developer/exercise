namespace TinyERP.Common.Common.Task
{
    public interface IBaseTask
    {
        int Priority { get; }
        void Execute(ITaskArgument arg);
    }
}