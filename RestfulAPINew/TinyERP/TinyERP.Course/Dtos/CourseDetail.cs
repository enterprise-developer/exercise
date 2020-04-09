using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.Course.Dtos
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuthorInfo Author { get; set; }
    }
}
