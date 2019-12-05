namespace TinyERP.UserMangement.Command
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.CQRS;
    using TinyERP.Common.Tasks;
    using TinyERP.UserManagement.Share.Dto;

    public class Bootstrapper:BaseTask, IBootStrapper
    {
        public Bootstrapper():base(Common.ApplicationType.All){}
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<ICommandHandler<CreateUserRequest>, UserCommandHandler>();
        }
    }
}
