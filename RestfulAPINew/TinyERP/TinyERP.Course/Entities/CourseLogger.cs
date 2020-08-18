using System;
using System.ComponentModel.DataAnnotations.Schema;
using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.Course.Context;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    public class CourseLogger: BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
    }
}
