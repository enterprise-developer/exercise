namespace TinyERP.Course.Dto
{
    public class CreateCourseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseAuthor Author { get; set; }
    }

    public class CourseAuthor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
