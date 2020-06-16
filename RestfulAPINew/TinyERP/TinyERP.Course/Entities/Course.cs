using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
