using TinyERP.Common.Common.IoC;
using TinyERP.Common.Common.Task;
namespace TinyERP.Course.Share.Task
{
    using TinyERP.Common.Tasks;
    using TinyERP.Course.Dto;
    using TinyERP.Course.Service;
    public class CreateSeedDataCourseDbContext : BaseTask, IApplicationReady
    {
        protected override void ExecuteInternal()
        {
            ICourseService courseService = IoC.Resolve<ICourseService>();
            CreateCourseRequest request = new CreateCourseRequest();
            request.Author = new CourseAuthor()
            {
                FirstName = "HUYEN",
                LastName = "nGUYEN",
                UserName = "HEHE"
            };
            request.Name = "test Course";
            request.Description = "create course";
            courseService.CreateCourse(request);
        }
    }
}
