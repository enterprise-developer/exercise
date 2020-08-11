using TinyERP.Common.CQRS;

namespace TinyERP.Course.Commands
{
    public class UpdateCourseCommand : BaseCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
