using System;
using TinyERP.Common;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Events
{
    public class OnCourseCreated : BaseEvent
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public OnCourseCreated() : base(EventPriority.High)
        {
        }
    }
}
