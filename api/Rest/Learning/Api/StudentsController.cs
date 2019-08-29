using Learning.Dto;
using Learning.Entity;
using Learning.Services;
using System.Collections.Generic;
using System.Web.Http;
using TinyERP.Common.Attribute;
using TinyERP.Common.IoC;
namespace Learning.Api
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        [Route("")]
        [ResponseWrapper()]
        [HttpGet()]
        public IList<Student> GetStudents()
        {
            IStudentService service = IoC.Container.Resolve<IStudentService>();
            return service.GetStudents();
        }

        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public Student AddStudent(CreateStudentRequest request)
        {
            IStudentService service = IoC.Container.Resolve<IStudentService>();
            return service.AddStudent(request);
        }
    }
}
