namespace Learning.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using TinyERP.Common.Attribute;

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
    }
}
