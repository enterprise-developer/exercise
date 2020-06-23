using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entities
{
    [DbContext(Use =typeof(CourseContext))]
    public class Lecture : BaseEntity
    {
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
    }
}
