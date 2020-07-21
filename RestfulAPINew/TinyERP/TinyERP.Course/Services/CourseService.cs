using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.UnitOfWork;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Entities;
using TinyERP.Course.Reponsitories;
using TinyERP.UserManagement.Share.Dtos;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.Course.Services
{
    public class CourseService : ICourseService
    {
        public CreateCourseResponse Create(CreateCourseRequest createCourse)
        {
            CourseAggregateRoot createdCourse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                createdCourse = new CourseAggregateRoot(createCourse);
                ICourseRepository repo = IoC.Resolve<ICourseRepository>(uow.Context);
                createdCourse = repo.Create(createdCourse);
                uow.Commit();
            }
            CreateCourseResponse courseResponse = new CreateCourseResponse()
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Description = createdCourse.Description
            };
            return courseResponse;
        }
        public UpdateCourseResponse Update(UpdateCourseRequest updateCourseDto)
        {
            CourseAggregateRoot updatedCourse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                ICourseRepository repository = IoC.Resolve<ICourseRepository>(uow.Context);
                updatedCourse = repository.GetById(updateCourseDto.Id);
                updatedCourse.Update(updateCourseDto);
                repository.Update(updatedCourse);
                uow.Commit();
            }
            UpdateCourseResponse updateCourseResponse = new UpdateCourseResponse()
            {
                CourseId = updatedCourse.Id,
                Name = updatedCourse.Name,
                Description = updatedCourse.Description
            };
            return updateCourseResponse;
        }

        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            Entities.CourseAggregateRoot course = repo.GetById(id);
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

        public int CreateSection(CreateSectionDto request)
        {
            this.Validate(request);
            int id;
            using (IUnitOfWork uow = new UnitOfWork<Entities.Section>())
            {
                ISectionRepository repo = IoC.Resolve<ISectionRepository>(uow.Context);
                Section section = new Section()
                {
                    Name = request.SectionName,
                    Index = request.Index,
                    CourseId = request.CourseId
                };
                section = repo.Create(section);
                uow.Commit();
                id = section.Id;
            }
            return id;
        }
        private void Validate(CreateSectionDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository courseRepo = IoC.Resolve<ICourseRepository>();
            Entities.CourseAggregateRoot course = courseRepo.GetById(request.CourseId);
            if (course == null)
            {
                errors.Add(new Error("course.addSection.courseWasNotExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        public int CreateLecture(CreateLectureDto request)
        {
            this.Validate(request);
            int id;
            using (IUnitOfWork uow = new UnitOfWork<Entities.Lecture>())
            {
                ILectureRepository repo = IoC.Resolve<ILectureRepository>(uow.Context);
                Lecture lecture = new Lecture()
                {
                    CourseId = request.CourseId,
                    SectionId = request.SectionId,
                    Name = request.Name,
                    Description = request.Description,
                    VideoLink = request.VideoLink
                };
                lecture = repo.Create(lecture);
                uow.Commit();
                id = lecture.Id;
            }
            return id;
        }
        private void Validate(CreateLectureDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository courseRepo = IoC.Resolve<ICourseRepository>();
            Entities.CourseAggregateRoot course = courseRepo.GetById(request.CourseId);
            if (course == null)
            {
                errors.Add(new Error("course.addLecture.courseWasNotExisted"));
            }
            ISectionRepository sectionRepo = IoC.Resolve<ISectionRepository>();
            Entities.Section section = sectionRepo.GetById(request.SectionId);
            if (section == null)
            {
                errors.Add(new Error("course.addLecture.sectionWasNotExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
