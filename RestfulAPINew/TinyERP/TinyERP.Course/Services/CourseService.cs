using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Mappers;
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
            CreateCourseResponse courseResponse = ObjectMapper.Map<CourseAggregateRoot, CreateCourseResponse>(createdCourse);
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
            UpdateCourseResponse updateCourseResponse = ObjectMapper.Map(updatedCourse,
                (UpdateCourseResponse updateCourse, CourseAggregateRoot course) =>
                {
                    updateCourse.CourseId = course.Id;
                });
            updateCourseResponse.CourseId = updatedCourse.Id;

            return updateCourseResponse;
        }

        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            Entities.CourseAggregateRoot course = repo.GetById(id);
            ValidationHelper.ThrowIfNull(course, "course.courseDetail.courseNotExisted");

            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            AuthorInfo author = await userFacade.GetAuthor(course.AuthorId);

            CourseDetail courseDetail = ObjectMapper.Map<CourseAggregateRoot, CourseDetail>(course);
            courseDetail.Author = author;
            return courseDetail;
        }

        public CreateCourseSectionResponse CreateSection(CreateCourseSectionRequest request)
        {
            CreateCourseSectionResponse courseSectionResponse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>(uow.Context);
                CourseAggregateRoot courseAggregate = courseRepository.GetById(request.CourseId, "Sections");
                ValidationHelper.ThrowIfNull(courseAggregate, "course.addSection.courseNotExisted");
                courseSectionResponse = courseAggregate.AddSection(request);
                courseRepository.Update(courseAggregate);
                uow.Commit();
            }
            return courseSectionResponse;
        }

        public CreateCourseLectureResponse CreateLecture(CreateLectureRequest request)
        {
            CreateCourseLectureResponse courseLectureResponse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>(uow.Context);
                CourseAggregateRoot courseAggregate = courseRepository.GetById(request.CourseId, "Sections,Sections.Lectures");
                ValidationHelper.ThrowIfNull(courseAggregate, "course.addLecture.courseNotExisted");
                courseLectureResponse = courseAggregate.AddLecture(request);
                courseRepository.Update(courseAggregate);
                uow.Commit();
            }

            return courseLectureResponse;
        }

        public void MoveSectionUp(MoveCourseSectionUpRequest request)
        {
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                ICourseRepository courseRepo = IoC.Resolve<ICourseRepository>(uow.Context);
                CourseAggregateRoot aggregate = courseRepo.GetById(request.CourseId, "Sections");

                ValidationHelper.ThrowIfNull(aggregate, "course.moveSectionUp.courseNotExisted");

                aggregate.MoveSectionUp(request.SectionId);
                courseRepo.Update(aggregate);
                uow.Commit();
            }
        }
    }
}
