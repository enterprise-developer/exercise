using TinyERP.Common.Entities;

namespace TinyERP.Course.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
