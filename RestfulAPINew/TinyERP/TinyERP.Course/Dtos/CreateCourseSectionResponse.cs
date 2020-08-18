using System;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseSectionResponse
    {
        public Guid CourseId { get; set; }
        public string SectionName { get; set; }
        public int Index { get; set; }
    }
}
