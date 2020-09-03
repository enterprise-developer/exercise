using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Events;

namespace TinyERP.Course.EventHandlers
{
    public class RegisterEventTask : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IEventHandler<OnCourseCreated>, CourseEventHandler>("Course.OnCourseCreated");
            IoC.RegisterTransient<IEventHandler<OnCourseCreated>, CourseEmailEventHandler>("Course.Email.OnCourseCreated");
            IoC.RegisterTransient<IEventHandler<OnLogCourseCreated>, CourseEventHandler>("Course.Log.OnCourseCreated");
            IoC.RegisterTransient<IEventHandler<OnCourseUpdated>, CourseEventHandler>("Course.OnCourseUpdated");
            IoC.RegisterTransient<IEventHandler<OnCourseSectionCreated>, CourseEventHandler>("Course.OnCourseSectionCreated");
            IoC.RegisterTransient<IEventHandler<OnCourseSectionLectureCreated>, CourseEventHandler>("Course.OnCourseSectionLectureCreated");
        }
    }
}
