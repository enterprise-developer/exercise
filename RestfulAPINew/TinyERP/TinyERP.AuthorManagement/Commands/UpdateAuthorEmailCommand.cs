using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class UpdateAuthorEmailCommand : IBaseCommand
    {
        public int AuthorId { get; set; }
        public string Email { get; set; }
    }
}
