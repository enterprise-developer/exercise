namespace TinyERP.Course.Query.Dtos
{
    public class CourseDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionCount { get; set; }
    }
}
