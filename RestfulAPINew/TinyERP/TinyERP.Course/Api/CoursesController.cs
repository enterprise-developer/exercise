using System;
using System.Web.Http;
using TinyERP.Common.Responses;
using TinyERP.Common.Validations;
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
            CourseService service = new CourseService();
            return service.Create(createCouseDto);
        }

        [Route("{id}")]
        [HttpPut()]
        [ResponseWrapper()]
        public Entities.Course Update(int id, UpdateCourseDto updateCourseDto)
        {
            CourseService service = new CourseService();
            updateCourseDto.Id = id;
            return service.Update(updateCourseDto);
        }

    }
}
