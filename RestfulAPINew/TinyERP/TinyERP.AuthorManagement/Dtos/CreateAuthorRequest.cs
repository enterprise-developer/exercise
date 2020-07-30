using TinyERP.Common.Attributes;

namespace TinyERP.AuthorManagement.Dtos
{
    public class CreateAuthorRequest
    {
        [Required("author.createAuthor.firstNameWasRequired")]
        public string FirstName { get; set; }
        [Required("author.createAuthor.lastNameWasRequired")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
