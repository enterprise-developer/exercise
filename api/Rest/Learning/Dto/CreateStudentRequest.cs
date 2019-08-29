using TinyERP.Common.Attribute;

namespace Learning.Dto
{
    public class CreateStudentRequest
    {
        [Required("learning.addNewStudent.firstNameIsRequired")]
        [MaxLength((int)StudentValidationRules.MaxLength,"learning.addNewStudent.firstNameUnderMinLength")]
        [MinLength((int)StudentValidationRules.MinLength, "learning.addNewStudent.firstNameUnderMinLength")]
        public string FirstName { get; set; }
        [Required("learning.addNewStudent.lastNameIsRequired")]
        [MaxLength((int)StudentValidationRules.MaxLength, "learning.addNewStudent.lastNameExcessMaxLength")]
        [MinLength((int)StudentValidationRules.MinLength, "learning.addNewStudent.lastNameUnderMinLength")]
        public string LastName { get; set; }
        [Required("learning.addNewStudent.userNameIsRequired")]
        [MaxLength((int)StudentValidationRules.MaxLength, "learning.addNewStudent.userNameExcessMaxLength")]
        [MinLength((int)StudentValidationRules.MinLength, "learning.addNewStudent.userNameUnderMinLength")]
        public string UserName { get; set; }
    }
}
