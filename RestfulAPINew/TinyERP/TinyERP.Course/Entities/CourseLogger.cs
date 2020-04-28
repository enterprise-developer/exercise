using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyERP.Course.Entities
{
    public class CourseLogger
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
    }
}
