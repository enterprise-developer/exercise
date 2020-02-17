using System.Web.Http;
using TinyERP.Common.Responses;
using TinyERP.Course.Dtos;
using TinyERP.Course.Services;

namespace TinyERP.Course.Api
{
    [RoutePrefix("api/courses")]
    public class CoursesController: ApiController
    {
        [Route("")]
        [HttpPost()]
        public Response<TinyERP.Course.Entities.Course> CreateCourse(CreateCourseDto createCouseDto)
        {
            CourseService service = new CourseService();
            return service.Create(createCouseDto);
        } 
    }
}
