namespace TinyERP.Common.Tasks
{
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Config;
    public class BaseTask : IBaseTask
    {
        public ApplicationType AppType { get; private set; }
        public int Priority { get; private set; }
        public BaseTask(ApplicationType appType = ApplicationType.All, TaskPriority priority = TaskPriority.Normal)
        {
            this.AppType = appType;
            this.Priority = (int)priority;
        }
        protected bool Enable
        {
            get
            {
                ApplicationTaskElement config = Configuration.Instance.ApplicationTasks[this.GetType().FullName];
                TaskRunningMode runningMode = Configuration.Instance.ApplicationTasks.Mode;
                return config != null ? config.Enable : runningMode == TaskRunningMode.AllowAll;
            }
        }

        public void Execute(ITaskArgument arg)
        {
            if (!this.Enable || (this.AppType!=ApplicationType.All && arg.Application.Type!=this.AppType)) { return; }
            this.ExecuteInternal(arg);
        }

        protected virtual void ExecuteInternal(ITaskArgument arg) { }
    }
}
