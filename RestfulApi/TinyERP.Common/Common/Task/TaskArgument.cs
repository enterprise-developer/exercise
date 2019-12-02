namespace TinyERP.Common.Common.Task
{
    using TinyERP.Common.Application;
    public class TaskArgument:ITaskArgument
    {
        public object Data { get; set; }
        public IApplication Application { get; set; }
        public TaskArgument(object data=null)
        {
            this.Data = data;
        }
    }
}
