using TinyERP.Common.Attribute;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entity
{
    [DbContext(Use=typeof(ICourseDbContext))]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
