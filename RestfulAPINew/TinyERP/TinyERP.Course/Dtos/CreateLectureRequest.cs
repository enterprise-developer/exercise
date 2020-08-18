using System;

namespace TinyERP.Course.Dtos
{
    public class CreateLectureRequest
    {
        public Guid CourseId { get; set; }
        public Guid SectionId { get; set; }
        public string VideoLink { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
