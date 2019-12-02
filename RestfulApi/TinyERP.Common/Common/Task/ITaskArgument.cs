namespace TinyERP.Common.Common.Task
{
    using TinyERP.Common.Application;
    public interface ITaskArgument
    {
        IApplication Application { get; set; }
        object Data { get; set; }
    }
}
