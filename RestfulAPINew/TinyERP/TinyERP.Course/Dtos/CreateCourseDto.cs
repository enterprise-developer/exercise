using TinyERP.Common.Attributes;
using TinyERP.Course.Const;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseDto
    {
        [Required("course.addOrUpdateCourse.nameWasRequired")]
        [MinLength("course.addOrUpdateCourse.nameWasUnderMinLength", CourseValidationRules.Course_Name_Min_Length)]
        [MaxLength("course.addOrUpdateCourse.nameWasExceedMaxLenght", CourseValidationRules.Course_Name_Max_Length)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
