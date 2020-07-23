using System.ComponentModel.DataAnnotations.Schema;
using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    public class Lecture : BaseEntity
    {
        public int CourseId { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string Test { get; set; }
    }
}
