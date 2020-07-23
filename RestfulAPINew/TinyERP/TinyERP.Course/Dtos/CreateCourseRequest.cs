using TinyERP.Common.Attributes;
using TinyERP.Course.Const;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseRequest
    {
        [Required("course.addOrUpdateCourse.nameWasRequired")]
        //[MinLength("course.addOrUpdateCourse.nameWasUnderMinLength", CourseValidationRules.Course_Name_Min_Length)]
        //[MaxLength("course.addOrUpdateCourse.nameWasExceedMaxLenght", CourseValidationRules.Course_Name_Max_Length)]
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateAuthorDto Author{ get; set; }

    }
}
