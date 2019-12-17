namespace TinyERP.UserMangement.Event
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Event;
    using TinyERP.Common.Tasks;
    using TinyERP.UserMangement.Event.User;

    public class Bootstrapper: BaseTask, IBootstrapper
    {
        public Bootstrapper():base(Common.ApplicationType.All){}

        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<IEventHandler<OnUserCreated>, UserEventHandler>();
            IoC.RegisterAsTransient<IEventHandler<OnUserUpdated>, UserEventHandler>();
        }
    }
}
