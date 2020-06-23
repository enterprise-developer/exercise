using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    public class Section : BaseEntity
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int CourseId { get; set; }
    }
}
