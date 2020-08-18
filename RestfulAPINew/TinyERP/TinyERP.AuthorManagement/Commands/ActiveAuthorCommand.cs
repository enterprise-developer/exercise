using System;
using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class ActiveAuthorCommand : BaseCommand
    {
        public ActiveAuthorCommand(Guid authorId): base(authorId)
        {
        }
    }
}
