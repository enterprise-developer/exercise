using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Commands
{
    public class MoveCourseSectionUpCommand : BaseCommand
    {
        public MoveCourseSectionUpCommand(Guid courseId, Guid sectionId): base(courseId)
        {
            this.SectionId = sectionId;
        }
        //public int CourseId { get; set; }
        public Guid SectionId { get; set; }
    }
}
