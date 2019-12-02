
using TinyERP.Common.Common.Task;

namespace TinyERP.Common.Tasks
{
    public class ConfigWebApiTask : BaseTask, IApplicationStarted
    {
        public ConfigWebApiTask():base(ApplicationType.Console)
        {

        }
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            
        }
    }
}
