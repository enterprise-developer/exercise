using System;
using System.Web.Http;
using TinyERP.AuthorManagement.Commands;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Responses;

namespace TinyERP.AuthorManagement.Api
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public void Create(CreateAuthorCommand authorCommand)
        {
            ICommandHandler<CreateAuthorCommand> command = IoC.Resolve<ICommandHandler<CreateAuthorCommand>>();
            command.Handle(authorCommand);
        }

        [Route("{authorId}/updateEmail")]
        [HttpPut()]
        [ResponseWrapper()]
        public void UpdateEmail(Guid authorId, [FromBody] string email)
        {
            UpdateAuthorEmailCommand updateAuthorEmail = new UpdateAuthorEmailCommand(authorId);
            updateAuthorEmail.Email = email;
            ICommandHandler<UpdateAuthorEmailCommand> command = IoC.Resolve<ICommandHandler<UpdateAuthorEmailCommand>>();
            command.Handle(updateAuthorEmail);
        }

        [Route("{authorId}/active")]
        [HttpPost()]
        [ResponseWrapper()]
        public void ActiveAuthor(Guid authorId)
        {
            ActiveAuthorCommand request = new ActiveAuthorCommand(authorId);
            ICommandHandler<ActiveAuthorCommand> command = IoC.Resolve<ICommandHandler<ActiveAuthorCommand>>();
            command.Handle(request);
        }

        [Route("{authorId}")]
        [HttpPut()]
        [ResponseWrapper()]
        public void Update(Guid authorId, [FromBody] UpdateAuthorCommand command)
        {
            command.SetAggregateId(authorId);
            ICommandHandler<UpdateAuthorCommand> commandHandler = IoC.Resolve<ICommandHandler<UpdateAuthorCommand>>();
            commandHandler.Handle(command);
        }
    }
}
