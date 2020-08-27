using TinyERP.Common.CQRS;

namespace TinyERP.Course.EventHandlers
{
    public class OnLogCourseCreated : BaseEvent
    {
        public string Message { get; set; }
    }
}
