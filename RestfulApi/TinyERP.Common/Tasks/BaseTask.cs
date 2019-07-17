using TinyERP.Common.Common.Task;
using TinyERP.Common.Config;

namespace TinyERP.Common.Tasks
{
    public class BaseTask : IBaseTask
    {
        protected bool Enable
        {
            get
            {
                ApplicationTaskElement config = Configuration.Instance.ApplicationTasks[this.GetType().FullName];
                return config == null || config.Enable;
            }
        }

        public void Execute()
        {
            if (!this.Enable) { return; }
            this.ExecuteInternal();
        }

        protected virtual void ExecuteInternal() { }
    }
}
