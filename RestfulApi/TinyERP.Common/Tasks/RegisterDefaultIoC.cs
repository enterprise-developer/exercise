namespace TinyERP.Common.Tasks
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Logging;

    public class RegisterDefaultIoC: BaseTask, IBootstrapper
    {
        public RegisterDefaultIoC() : base(ApplicationType.All, TaskPriority.High) { }
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsSingleton<ILogger, FileLogger>();
        }
    }
}
