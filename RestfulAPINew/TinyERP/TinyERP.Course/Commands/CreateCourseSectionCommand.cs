using TinyERP.Common.Attributes;
using TinyERP.Common.CQRS;

namespace TinyERP.Course.Commands
{
    public class CreateCourseSectionCommand : BaseCommand
    {      
        [Required("courses.addSection.nameIsRequired")]
        //[MinLength("courses.addSection.sectionNameWasUnderMinLength", CourseValidationRules.Section_Name_Min_Length)]
        //[MaxLength("courses.addSection.sectionNameWasExceedMaxLength", CourseValidationRules.Section_Name_Max_Length)]
        public string SectionName { get; set; }
        public int Index { get; set; }
    }
}
