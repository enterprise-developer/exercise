using System;
using System.ComponentModel.DataAnnotations.Schema;
using TinyERP.Common.Entities;

namespace TinyERP.Course.Entities
{
    public class CourseLogger: BaseEntity<int>
    {
        public int CourseId { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
    }
}
