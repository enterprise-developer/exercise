namespace TinyERP.Common.Application
{
    using System;
    using System.Collections.Generic;
    using TinyERP.Common.Common.Helper;
    using TinyERP.Common.Common.Task;
    internal abstract class BaseApplication: IApplication
    {
        public ApplicationType Type { get; private set; }
        public BaseApplication(ApplicationType type)
        {
            this.Type = type;
        }
        public virtual void OnApplicationEnding()
        {
            AssemblyHelper.Execute<IApplicationEnd>(this.GetTaskArgument());

        }
        private ITaskArgument GetTaskArgument() {
            ITaskArgument arg = new TaskArgument();
            arg.Application = this;
            return arg;
        }

        public virtual void OnApplicationStarting()
        {
            AssemblyHelper.Execute<IApplicationStarted>(this.GetTaskArgument());
            AssemblyHelper.Execute<IBootstrapper>(this.GetTaskArgument());
        }

        public void OnErrors(IList<Exception> errors)
        {
            ITaskArgument arg = this.GetTaskArgument();
            arg.Data = errors;
            AssemblyHelper.Execute<IApplicationError>(arg);
        }
    }
}
