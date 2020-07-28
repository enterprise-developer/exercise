using TinyERP.Common.Attributes;

namespace TinyERP.Course.Dtos
{
    public class MoveCourseSectionUpRequest
    {
        public int CourseId { get; set; }
        public int SectionId { get; set; }
    }
}
