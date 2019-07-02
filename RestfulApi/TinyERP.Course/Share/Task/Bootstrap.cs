namespace TinyERP.Course.Share.Task
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Course.Service;
    using TinyERP.UserManagement.Share.Facade;

    public class Bootstrap : IBootStrapper
    {
        public void Execute()
        {
            IoC.RegisterAsSingleton<ICourseService, CourseService>();
        }
    }
}
