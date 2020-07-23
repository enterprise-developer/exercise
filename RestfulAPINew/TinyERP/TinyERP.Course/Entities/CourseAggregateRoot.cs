using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TinyERP.Common.Attributes;
using TinyERP.Common.DI;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Context;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    [Table("Courses")]
    public class CourseAggregateRoot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }

        public ICollection<Section> Sections { get; set; }

        public CourseAggregateRoot()
        {
            this.Sections = new List<Section>();
        }
        public CourseAggregateRoot(CreateCourseRequest request) : this()
        {
            this.Validate(request);
            this.Name = request.Name;
            this.Description = request.Description;
        }

        private void Validate(CreateCourseRequest request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            CourseAggregateRoot course = repo.GetByName(request.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        public void Update(UpdateCourseRequest updateCourseRequest)
        {
            this.Validate(updateCourseRequest);
            this.Name = updateCourseRequest.Name;
            this.Description = updateCourseRequest.Description;
        }


        private void Validate(UpdateCourseRequest request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repository = IoC.Resolve<ICourseRepository>();
            CourseAggregateRoot course = repository.GetById(request.Id);

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

        public CreateCourseSectionResponse AddSection(CreateCourseSectionRequest request)
        {
            this.Validate(request);
            Section section = new Section()
            {
                CourseId = request.CourseId,
                CreatedDate = DateTime.Now,
                Index = request.Index,
                Name = request.SectionName
            };
            this.Sections.Add(section);
            CreateCourseSectionResponse courseResponse = new CreateCourseSectionResponse()
            {
                CourseId = request.CourseId,
                SectionName = request.SectionName,
                Index = request.Index
            };
            return courseResponse;
        }


        private void Validate(CreateCourseSectionRequest request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ISectionRepository sectionRepository = IoC.Resolve<ISectionRepository>();
            bool isExist = sectionRepository.IsExistSectionByName(request.SectionName);
            if (this.Sections.Any(item => item.Name == request.SectionName) || isExist)
            {
                errors.Add(new Error("course.addSection.sectionNameWasExited"));
            }

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        public CreateCourseLectureResponse AddLecture(CreateLectureRequest request)
        {
            this.Validate(request);
            Section section = this.Sections.FirstOrDefault(item => item.Id == request.SectionId);
            Lecture lecture = new Lecture()
            {
                CourseId = request.CourseId,
                SectionId = request.SectionId,
                Name = request.Name,
                Description = request.Description,
                VideoLink = request.VideoLink,
                Section = section
            };            
            section.Lectures.Add(lecture);
            CreateCourseLectureResponse response = new CreateCourseLectureResponse()
            {
                CourseId = request.CourseId,
                SectionId = request.SectionId,
                Name = request.Name,
                Description = request.Description,
                VideoLink = request.VideoLink
            };

            return response;
        }

        private void Validate(CreateLectureRequest request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            if (!this.Sections.Any(item => item.Id == request.SectionId))
            {
                errors.Add(new Error("course.addLecture.sectionWasNotExisted"));
            }
            Section section = this.Sections.FirstOrDefault(item => item.Id == request.SectionId);
            if (section != null && section.Lectures.Any(item => item.Name.Equals(request.Name)))
            {
                errors.Add(new Error("course.addLecture.nameWasExisted"));
            }

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
