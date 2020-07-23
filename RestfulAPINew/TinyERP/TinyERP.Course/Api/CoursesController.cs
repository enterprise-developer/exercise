namespace TinyERP.Course.Api
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using TinyERP.Common.DI;
    using TinyERP.Common.Responses;
    using TinyERP.Course.Dtos;
    using TinyERP.Course.Services;

    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseResponse CreateCourse(CreateCourseRequest request)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.Create(request);
        }

        [Route("{id}")]
        [HttpPut()]
        [ResponseWrapper()]
        public UpdateCourseResponse Update(int id, UpdateCourseRequest updateCourseRequest)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            updateCourseRequest.Id = id;
            return service.Update(updateCourseRequest);
        }

        [Route("{id}")]
        [HttpGet()]
        [ResponseWrapper()]
        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            return await service.GetCourseDetail(id);
        }

        [Route("{courseId}/sections")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseSectionResponse CreateSection(int courseId, CreateCourseSectionRequest request)
        {
            request.CourseId = courseId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateSection(request);
        }

        [Route("{courseId}/sections/{sectionId}/lectures")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseLectureResponse CreateLecture(int courseId, int sectionId, CreateLectureRequest request)
        {
            request.CourseId = courseId;
            request.SectionId = sectionId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateLecture(request);
        }
    }
}
