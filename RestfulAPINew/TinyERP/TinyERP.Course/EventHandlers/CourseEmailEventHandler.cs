using System;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Logs;
using TinyERP.Course.Events;

namespace TinyERP.Course.EventHandlers
{
    public class CourseEmailEventHandler : IEventHandler<OnCourseCreated>
    {
        public void Handle(OnCourseCreated ev)
        {
            ILogger logger = IoC.Resolve<ILogger>();
            logger.Error(new Exception("Test Email Handle"));
        }
    }
}
