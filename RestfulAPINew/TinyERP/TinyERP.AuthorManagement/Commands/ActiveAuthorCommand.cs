using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class ActiveAuthorCommand : BaseCommand
    {
        public ActiveAuthorCommand(int authorId): base(authorId)
        {
        }
    }
}
