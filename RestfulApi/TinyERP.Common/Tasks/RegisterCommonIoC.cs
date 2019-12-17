namespace TinyERP.Common.Tasks
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Event;

    public class RegisterCommonIoC: BaseTask, IBootstrapper
    {
        public RegisterCommonIoC():base(ApplicationType.All){}

        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<IEventManager, EventManager>();
        }
    }
}
