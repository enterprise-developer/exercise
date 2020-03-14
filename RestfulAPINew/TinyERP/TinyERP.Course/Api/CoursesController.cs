using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Responses;
using TinyERP.Course.Dtos;
using TinyERP.Course.Services;

namespace TinyERP.Course.Api
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public TinyERP.Course.Entities.Course CreateCourse(CreateCourseDto createCouseDto)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.Create(createCouseDto);
        }

        [Route("{id}")]
        [HttpPut()]
        [ResponseWrapper()]
        public Entities.Course Update(int id, UpdateCourseDto updateCourseDto)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            updateCourseDto.Id = id;
            return service.Update(updateCourseDto);
        }

    }
}
