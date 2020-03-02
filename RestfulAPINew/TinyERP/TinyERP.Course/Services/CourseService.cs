using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.Helpers;
using TinyERP.Common.Responses;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Services
{
    public class CourseService : ICourseService
    {
        public TinyERP.Course.Entities.Course Create(CreateCourseDto createCourse)
        {
            this.Validate(createCourse);
            CourseRepository respository = new CourseRepository();
            Entities.Course course = new Entities.Course()
            {
                Name = createCourse.Name,
                Description = createCourse.Description
            };

            Entities.Course itemAdded = respository.Create(course);

            return itemAdded;
        }

        private void Validate(CreateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            CourseRepository repo = new CourseRepository();
            Entities.Course course = repo.GetByName(request.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        public Entities.Course Update(UpdateCourseDto updateCourseDto)
        {
            this.Validate(updateCourseDto);
            
            CourseRepository repository = new CourseRepository();
            Entities.Course itemExisted = repository.GetById(updateCourseDto.Id);
            itemExisted.Name = updateCourseDto.Name;
            itemExisted.Description = updateCourseDto.Description;
            repository.Update(itemExisted);

            return itemExisted;

        }

        private void Validate(UpdateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            CourseRepository repository = new CourseRepository();
            Entities.Course course = repository.GetById(request.Id);

            if (course == null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.courseNotExisted"));
                throw new ValidationException(errors);
            }

            bool isExist = repository.IsExistName(request.Name, request.Id);
            if (isExist)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
