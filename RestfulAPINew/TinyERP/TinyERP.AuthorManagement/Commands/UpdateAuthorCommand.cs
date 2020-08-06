using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class UpdateAuthorCommand: BaseCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
