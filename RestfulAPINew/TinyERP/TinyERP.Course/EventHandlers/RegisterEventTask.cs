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
            IoC.RegisterTransient<IEventHandler<OnCourseCreated>, CourseEventHandler>();
        }
    }
}
