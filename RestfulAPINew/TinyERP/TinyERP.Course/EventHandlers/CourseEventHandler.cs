using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Logs;
using TinyERP.Course.Events;
using TinyERP.Course.Query.Entities;

namespace TinyERP.Course.EventHandlers
{
    public class CourseEventHandler : IEventHandler<OnCourseCreated>, IEventHandler<OnCourseUpdated>, IEventHandler<OnLogCourseCreated>,
        IEventHandler<OnCourseSectionCreated>
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
            collection.Save(courseDetail);
        }
    }
}
