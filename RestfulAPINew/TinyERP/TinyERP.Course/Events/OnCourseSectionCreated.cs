using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Events
{
    public class OnCourseSectionCreated : BaseEvent
    {
        public Guid CourseId { get; set; }
    }
}
