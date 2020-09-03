using System;
using TinyERP.Common.CQRS;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Events
{
    public class OnCourseSectionCreated : BaseEvent
    {
        public Guid CourseId { get; set; }
        public CourseSection Section { get; set; }
    }
}
