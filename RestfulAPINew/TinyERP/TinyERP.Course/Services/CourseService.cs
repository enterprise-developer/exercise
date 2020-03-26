using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.Course.Services
{
    public class CourseService : ICourseService
    {
        public TinyERP.Course.Entities.Course Create(CreateCourseDto createCourse)
        {
            this.Validate(createCourse);
            // mode remote
            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            int authorId = userFacade.CreateIfNotExist(createCourse.Author);
            ICourseRepository repository = IoC.Resolve<ICourseRepository>();
            Entities.Course course = new Entities.Course()
            {
                Name = createCourse.Name,
                Description = createCourse.Description
            };

            course.AuthorId = authorId;
            Entities.Course itemAdded = repository.Create(course);

            return itemAdded;
        }

        private void Validate(CreateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
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

            ICourseRepository repository = IoC.Resolve<ICourseRepository>();
            Entities.Course itemExisted = repository.GetById(updateCourseDto.Id);
            itemExisted.Name = updateCourseDto.Name;
            itemExisted.Description = updateCourseDto.Description;
            repository.Update(itemExisted);

            return itemExisted;
        }

        private void Validate(UpdateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repository = IoC.Resolve<ICourseRepository>();
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
