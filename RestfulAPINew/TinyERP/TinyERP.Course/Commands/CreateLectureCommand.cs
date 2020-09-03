using System;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Commands
{
    public class CreateLectureCommand: BaseCommand
    {     
        public Guid SectionId { get; set; }
        public string VideoLink { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
