using TinyERP.Common.Attributes;
using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class CreateAuthorCommand: BaseCommand
    {
        [Required("author.createAuthor.firstNameWasRequired")]
        public string FirstName { get; set; }
        [Required("author.createAuthor.lastNameWasRequired")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
