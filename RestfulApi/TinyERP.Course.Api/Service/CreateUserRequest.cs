using TinyERP.Common.Common.Validation.Attr;

namespace REST.Service
{
    public class CreateUserRequest
    {
        [Required("addNewUser.firstNameWasRequired")]
        public string FirstName { get; set; }
        [Required("addNewUser.lastNameWasRequired")]
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}