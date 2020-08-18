using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TinyERP.Common.Attributes;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Commands;
using TinyERP.Course.Context;
using TinyERP.Course.Dtos;
using TinyERP.Course.Events;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    [Table("Courses")]
    public class CourseAggregateRoot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }

        public ICollection<Section> Sections { get; set; }

        public CourseAggregateRoot()
        {
            this.Sections = new List<Section>();
        }
        //public CourseAggregateRoot(CreateCourseCommand request) : this()
        //{
        //    this.Validate(request);
        //    this.Name = request.Name;
        //    this.Description = request.Description;
        //}

        public CourseAggregateRoot(CreateCourseCommand command) : this()
        {
            this.Validate(command);
            this.Name = command.Name;
            this.Description = command.Description;
            OnCourseCreated courseEvent = new OnCourseCreated() {
                CourseId = this.Id,
                Name = this.Name,
                Description = this.Description
            };
            IEventHandler<OnCourseCreated> eventHandler = IoC.Resolve<IEventHandler<OnCourseCreated>>();
            eventHandler.Handle(courseEvent);
        }

        private void Validate(CreateCourseCommand command)
        {
            IList<Error> errors = ValidationHelper.Validate(command);
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            CourseAggregateRoot course = repo.GetByName(command.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        //private void Validate(CreateCourseCommand request)
        //{
        //    IList<Error> errors = ValidationHelper.Validate(request);
        //    ICourseRepository repo = IoC.Resolve<ICourseRepository>();
        //    CourseAggregateRoot course = repo.GetByName(request.Name);
        //    if (course != null)
        //    {
        //        errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
        //    }
        //    if (errors.Any())
        //    {
        //        throw new ValidationException(errors);
        //    }
        //}

        public void Update(UpdateCourseCommand command)
        {
            this.Validate(command);
            this.Name = command.Name;
            this.Description = command.Description;
        }

        private void Validate(UpdateCourseCommand command)
        {
            IList<Error> errors = ValidationHelper.Validate(command);
            ICourseRepository repository = IoC.Resolve<ICourseRepository>();
            CourseAggregateRoot course = repository.GetById(command.AggregateId);

            if (course == null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.courseNotExisted"));
                throw new ValidationException(errors);
            }

            bool isExist = repository.IsExistName(command.Name, command.AggregateId);
            if (isExist)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
        #region Section
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

        public void MoveSectionUp(Guid sectionId)
        {
            this.Validate(sectionId);
            Section section = this.Sections.FirstOrDefault(x => x.Id == sectionId);
            int newIndex = section.Index - 1;
            Section oldSection = this.Sections.FirstOrDefault(x => x.Index == newIndex);

            section.Index = section.Index - 1;
            oldSection.Index = oldSection.Index + 1;
        }

        private void Validate(Guid sectionId)
        {
            ISectionRepository sectionRepo = IoC.Resolve<ISectionRepository>();
            Section currentSection = sectionRepo.GetById(sectionId);
            if (currentSection == null)
            {
                throw new ValidationException("course.moveSectionUp.sectionNotExisted");
            }

            Section oldSection = this.Sections.FirstOrDefault(x => x.Index == (currentSection.Index - 1));
            if (oldSection == null)
            {
                throw new ValidationException("course.moveSectionUp.canNotMoveSectionUp");
            }
        }
        #endregion

        #region Lecture
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

        #endregion
    }
}
