namespace TinyERP.Course.Share.Task
{
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Common.Task;
    using TinyERP.Common.Tasks;
    using TinyERP.Course.Data.Repositories;
    using TinyERP.Course.Repositories;
    using TinyERP.Course.Service;

    public class Bootstrap :BaseTask, IBootstrapper
    {
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<ICourseService, CourseService>();
            IoC.RegisterAsTransient<ICourseRepository, CourseRepository>();
        }
    }
}
