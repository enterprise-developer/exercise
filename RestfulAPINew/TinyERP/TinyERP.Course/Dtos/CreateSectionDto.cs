using TinyERP.Common.Attributes;
using TinyERP.Course.Const;

namespace TinyERP.Course.Dtos
{
    public class CreateSectionDto
    {
        public int CourseId { get; set; }
        [MinLength("courses.addSection.sectionNameWasUnderMinLength", CourseValidationRules.Section_Name_Min_Length)]
        [MaxLength("courses.addSection.sectionNameWasExceedMaxLength", CourseValidationRules.Section_Name_Max_Length)]
        public string SectionName { get; set; }
        public int Index { get; set; }
    }
}
