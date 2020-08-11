using TinyERP.Common.CQRS;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseResponse : IBaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
