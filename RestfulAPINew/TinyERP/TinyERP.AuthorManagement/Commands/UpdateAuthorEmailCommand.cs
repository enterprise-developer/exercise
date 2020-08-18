using System;
using TinyERP.Common.CQRS;

namespace TinyERP.AuthorManagement.Commands
{
    public class UpdateAuthorEmailCommand : BaseCommand
    {
        public string Email { get; set; }
        public UpdateAuthorEmailCommand(Guid authorId): base(authorId)
        {

        }
    }
}
