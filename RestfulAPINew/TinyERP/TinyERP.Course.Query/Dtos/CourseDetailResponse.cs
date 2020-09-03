using System;

namespace TinyERP.Course.Query.Dtos
{
    public class CourseDetailResponse
    {
        public Guid AggregateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionCount { get; set; }
    }
}
