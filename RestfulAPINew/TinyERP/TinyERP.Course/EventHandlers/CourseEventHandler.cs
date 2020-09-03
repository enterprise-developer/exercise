using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Logs;
using TinyERP.Course.Events;
using TinyERP.Course.Query.Entities;

namespace TinyERP.Course.EventHandlers
{
    public class CourseEventHandler : IEventHandler<OnCourseCreated>, IEventHandler<OnCourseUpdated>, IEventHandler<OnLogCourseCreated>,
        IEventHandler<OnCourseSectionCreated>, IEventHandler<OnCourseSectionLectureCreated>
    {
        public void Handle(OnCourseCreated ev)
        {
            MongoDatabase database = new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("tinyerp");
            MongoCollection<CourseDetail> collection = database.GetCollection<CourseDetail>("coursedetails");
            CourseDetail courseDetail = new CourseDetail()
            {
                AggregateId = ev.CourseId,
                Name = ev.Name,
                Description = ev.Description
            };
            collection.Insert(courseDetail);
        }

        public void Handle(OnCourseUpdated courseUpdated)
        {
            MongoDatabase database = new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("tinyerp");
            MongoCollection<CourseDetail> collection = database.GetCollection<CourseDetail>("coursedetails");
            CourseDetail courseDetail = collection.AsQueryable<CourseDetail>().FirstOrDefault(item => item.AggregateId == courseUpdated.CourseId);
            if (courseDetail != null)
            {
                courseDetail.Name = courseUpdated.Name;
                courseDetail.Description = courseUpdated.Description;
                collection.Save(courseDetail);
            }
        }

        public void Handle(OnLogCourseCreated ev)
        {
            ILogger logger = IoC.Resolve<ILogger>();
            logger.Error(new System.Exception("Test priority Event"));

        }

        public void Handle(OnCourseSectionCreated ev)
        {
            MongoDatabase database = new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("tinyerp");
            MongoCollection<CourseDetail> collection = database.GetCollection<CourseDetail>("coursedetails");
            CourseDetail courseDetail = collection.AsQueryable().FirstOrDefault(item => item.AggregateId == ev.CourseId);
            courseDetail.SectionCount += 1;

            CourseSection courseSection = new CourseSection()
            {
                SectionId = ev.Section.Id,
                Name = ev.Section.Name,
                Index = ev.Section.Index,
            };
            if (courseDetail.Sections == null)
            {
                courseDetail.Sections = new List<CourseSection>();
            }
            courseDetail.Sections.Add(courseSection);
            collection.Save(courseDetail);
        }

        public void Handle(OnCourseSectionLectureCreated ev)
        {
            MongoDatabase database = new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("tinyerp");
            MongoCollection<CourseDetail> collection = database.GetCollection<CourseDetail>("coursedetails");
            CourseDetail courseDetail = collection.AsQueryable().FirstOrDefault(item => item.AggregateId == ev.CourseId);
            var section = courseDetail.Sections?.FirstOrDefault(item => item.SectionId == ev.SectionId);
            if (section != null)
            {
                courseDetail.Sections.Remove(section);
                if (section.Lectures == null)
                {
                    section.Lectures = new List<CourseSectionLecture>();
                }
                section.Lectures.Add(new CourseSectionLecture()
                {
                    CourseId = ev.CourseId,
                    SectionId = ev.SectionId,
                    Name = ev.Name,
                    VideoLink = ev.VideoLink,
                    Description = ev.Description
                });
                section.LectureCount += 1;
                courseDetail.Sections.Add(section);
            }
            collection.Save(courseDetail);
        }
    }
}
