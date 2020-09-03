using System;

namespace TinyERP.Course.Query.Entities
{
    public class CourseSectionLecture
    {
        public Guid CourseId { get; set; }       
        public Guid SectionId { get; set; }     
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string Test { get; set; }
    }
}
