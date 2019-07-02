namespace REST.Task
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.UserMangement.Service;

    public class BootStrapper : IBootStrapper
    {
        public void Execute()
        {
            IoC.RegisterAsSingleton<IUserService, UserService>();
        }
    }
}