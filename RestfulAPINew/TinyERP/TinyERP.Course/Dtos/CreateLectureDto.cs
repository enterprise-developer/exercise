namespace TinyERP.Course.Dtos
{
    public class CreateLectureDto
    {
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public string VideoLink { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
