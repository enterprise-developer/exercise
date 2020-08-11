using TinyERP.Common.CQRS;

namespace TinyERP.Course.Commands
{
    public class MoveCourseSectionUpCommand : BaseCommand
    {
        public MoveCourseSectionUpCommand(int courseId, int sectionId): base(courseId)
        {
            this.SectionId = sectionId;
        }
        //public int CourseId { get; set; }
        public int SectionId { get; set; }
    }
}
