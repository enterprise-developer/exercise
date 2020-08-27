using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Logs;
using TinyERP.Common.UnitOfWork;
using TinyERP.Course.Events;
using TinyERP.Course.Query.Entities;
using TinyERP.Course.Query.Reponsitories;

namespace TinyERP.Course.EventHandlers
{
    public class CourseEventHandler : IEventHandler<OnCourseCreated>, IEventHandler<OnCourseUpdated>, IEventHandler<OnLogCourseCreated>
    {
        public void Handle(OnCourseCreated ev)
        {
            using (IUnitOfWork uow = new UnitOfWork<CourseDetail>())
            {
                CourseDetail courseDetail = new CourseDetail()
                {
                    AggregateId = ev.CourseId,
                    Name = ev.Name,
                    Description = ev.Description
                };
                ICourseQueryRepository courseQueryRepository = IoC.Resolve<ICourseQueryRepository>(uow.Context);
                
                courseQueryRepository.Create(courseDetail);
                uow.Commit();
            }
        }

        public void Handle(OnCourseUpdated courseUpdated)
        {
            using (IUnitOfWork uow = new UnitOfWork<CourseDetail>())
            {
                ICourseQueryRepository repository = IoC.Resolve<ICourseQueryRepository>(uow.Context);
                CourseDetail courseDetail = repository.GetByAggregateId(courseUpdated.CourseId);
                courseDetail.Name = courseUpdated.Name;
                courseDetail.Description = courseUpdated.Description;
                repository.Update(courseDetail);
                uow.Commit();
            }
        }

        public void Handle(OnLogCourseCreated ev)
        {
            ILogger logger = IoC.Resolve<ILogger>();
            logger.Error(new System.Exception("Test priority Event"));

        }
    }
}
