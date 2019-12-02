namespace TinyERP.UserManagement.Api.Tasks
{
    using TinyERP.Common;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Logging;
    using TinyERP.Common.Tasks;
    public class RegisterApplicationDependency: BaseTask, IBootStrapper
    {
        public RegisterApplicationDependency():base(ApplicationType.All, TaskPriority.High){}
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsSingleton<ILogger, FileLogger>();
        }
    }
}