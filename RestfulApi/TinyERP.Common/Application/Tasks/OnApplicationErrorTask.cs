namespace TinyERP.Common.Application.Tasks
{
    using System.Collections.Generic;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Logging;
    using TinyERP.Common.Tasks;

    public class OnApplicationErrorTask: BaseTask, IApplicationError
    {
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            ILogger logger = IoC.Resolve<ILogger>();
            IList<System.Exception> errors = arg.Data as IList<System.Exception>;
            foreach (System.Exception ex in errors) {
                logger.Error(ex);
            }
        }
    }
}
