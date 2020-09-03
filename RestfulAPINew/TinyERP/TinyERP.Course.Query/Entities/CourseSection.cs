using System;
using System.Collections.Generic;

namespace TinyERP.Course.Query.Entities
{
    public class CourseSection
    {
        public Guid SectionId { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int LectureCount { get; set; }

        public IList<CourseSectionLecture> Lectures { get; set; }
    }
}
