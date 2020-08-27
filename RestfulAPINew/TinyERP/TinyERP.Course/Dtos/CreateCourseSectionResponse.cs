using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseSectionResponse : IBaseResponse
    {
        public Guid CourseId { get; set; }
        public string SectionName { get; set; }
        public int Index { get; set; }
    }
}
