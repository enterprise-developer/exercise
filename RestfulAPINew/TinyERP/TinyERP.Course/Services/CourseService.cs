using System.Collections.Generic;
using System.Linq;
using System.Net;
using TinyERP.Common.Responses;
using TinyERP.Common.Vadations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Services
{
    public class CourseService
    {
        public Response<TinyERP.Course.Entities.Course> Create(CreateCourseDto createCourse)
        {
            Response<TinyERP.Course.Entities.Course> response = new Response<TinyERP.Course.Entities.Course>();
            IList<Error> errors = this.GetErrors(createCourse);
            if (errors.Any())
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Errors = errors;
            }
            else
            {
                CourseRepository respository = new CourseRepository();
                TinyERP.Course.Entities.Course course = new Entities.Course()
                {
                    Name = createCourse.Name,
                    Description = createCourse.Description
                };

                TinyERP.Course.Entities.Course itemAdded = respository.Create(course);

                response.StatusCode = HttpStatusCode.OK;
                response.Data = itemAdded;

            }

            return response;
        }

        private IList<Error> GetErrors(CreateCourseDto createCourseDto)
        {
            IList<Error> errors = new List<Error>();
            if (string.IsNullOrEmpty(createCourseDto.Name))
            {
                errors.Add(new Error("course.createCourse.nameWasRequired"));
                return errors;
            }

            if (createCourseDto.Name.Length < 6)
            {
                errors.Add(new Error("course.createCourse.nameWasUnderMinLenght"));
            }

            if (createCourseDto.Name.Length > 50)
            {
                errors.Add(new Error("course.createCourse.nameWasExceedMaxLenght"));
            }

            CourseRepository respository = new CourseRepository();
            TinyERP.Course.Entities.Course course = respository.GetByName(createCourseDto.Name);
            if (course != null)
            {
                errors.Add(new Error("course.createCourse.nameWasExisted"));
            }
            return errors;
        }
    }
}
