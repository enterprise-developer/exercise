using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using TinyERP.Common.Attributes;
using TinyERP.Common.Helpers;
using TinyERP.Common.Responses;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Services
{
    public class CourseService
    {
        public Response<TinyERP.Course.Entities.Course> Create(CreateCourseDto createCourse)
        {
            this.Validate(createCourse);
            Response<TinyERP.Course.Entities.Course> response = new Response<TinyERP.Course.Entities.Course>();
            CourseRepository respository = new CourseRepository();
            TinyERP.Course.Entities.Course course = new Entities.Course()
            {
                Name = createCourse.Name,
                Description = createCourse.Description
            };

            TinyERP.Course.Entities.Course itemAdded = respository.Create(course);

            response.StatusCode = HttpStatusCode.OK;
            response.Data = itemAdded;
            return response;
        }
        private void Validate(CreateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            CourseRepository repo = new CourseRepository();
            TinyERP.Course.Entities.Course course = repo.GetByName(request.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
