using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.UnitOfWork;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Context;
using TinyERP.Course.Dtos;
using TinyERP.Course.Entities;
using TinyERP.Course.Reponsitories;
using TinyERP.UserManagement.Share.Dtos;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.Course.Services
{
    public class CourseService : ICourseService
    {
        public TinyERP.Course.Entities.Course Create(CreateCourseDto createCourse)
        {
            //this.Validate(createCourse);
            Entities.Course course = new Entities.Course()
            {
                Name = createCourse.Name,
                Description = createCourse.Description
            };
            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            int authorId = userFacade.CreateIfNotExist(createCourse.Author).Result;
            course.AuthorId = authorId;
            Entities.Course itemAdded;
            using (IUnitOfWork uow = new UnitOfWork<Course1DbContext>())
            {
                ICourseRepository repository = IoC.Resolve<ICourseRepository>(uow.Context);
                itemAdded = repository.Create(course);
                ICourseLoggerRepository loggerRepository = IoC.Resolve<ICourseLoggerRepository>(uow.Context);
                CourseLogger courseLogger = new CourseLogger()
                {
                    CourseId = itemAdded.Id,
                    Message = "Course Create Success",
                    CreatedDate = DateTime.Now
                };
                loggerRepository.Create(courseLogger);
                uow.Commit();
            }
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
            Entities.Course itemExisted;
            using (IUnitOfWork uow = new UnitOfWork<CourseContext>())
            {
                ICourseRepository repository = IoC.Resolve<ICourseRepository>(uow.Context);
                itemExisted = repository.GetById(updateCourseDto.Id);
                itemExisted.Name = updateCourseDto.Name;
                itemExisted.Description = updateCourseDto.Description;
                uow.Commit();
            }
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

        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            Entities.Course course = repo.GetById(id);
            if (course == null)
            {
                throw new ValidationException("course.courseDetail.courseNotExisted");
            }

            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            AuthorInfo author = await userFacade.GetAuthor(course.AuthorId);

            CourseDetail courseDetail = new CourseDetail();
            courseDetail.Id = course.Id;
            courseDetail.Name = course.Name;
            courseDetail.Description = course.Description;
            courseDetail.Author = author;
            return courseDetail;
        }
    }
}
