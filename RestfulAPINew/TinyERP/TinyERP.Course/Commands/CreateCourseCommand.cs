using TinyERP.Common.Attributes;
using TinyERP.Common.CQRS;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.Course.Commands
{
    public class CreateCourseCommand : BaseCommand
    {
        [Required("course.addOrUpdateCourse.nameWasRequired")]
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateAuthorDto Author{ get; set; }

    }
}
