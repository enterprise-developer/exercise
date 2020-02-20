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
        public Response<TinyERP.Course.Entities.Course> CreateCourse(CreateCourseDto createCouseDto)
        {
            try
            {
                CourseService service = new CourseService();
                return service.Create(createCouseDto);
            }
            catch (ValidationException exs)
            {

                Response<TinyERP.Course.Entities.Course> response = new Response<Entities.Course>();
                response.Errors = exs.Errors;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
        }
    }
}
