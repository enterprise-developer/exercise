using System;
using System.ComponentModel.DataAnnotations.Schema;
using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Query.Context;

namespace TinyERP.Course.Query.Entities
{
    [DbContext(Use = typeof(CourseQueryDbContext))]
    [Table("CourseDetails")]
    public class CourseDetail : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionCount { get; set; }
    }
}
