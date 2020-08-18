using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Events
{
    public class OnCourseCreated : IEvent
    {
        public Guid CourseId  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
