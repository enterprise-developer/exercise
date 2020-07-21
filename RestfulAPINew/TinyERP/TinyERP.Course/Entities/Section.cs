using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public CourseAggregateRoot Course{ get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate{ get; set; }
    }
}
