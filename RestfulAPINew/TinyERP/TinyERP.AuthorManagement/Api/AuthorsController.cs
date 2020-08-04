using System.Web.Http;
using TinyERP.AuthorManagement.Commands;
using TinyERP.AuthorManagement.Dtos;
using TinyERP.AuthorManagement.Services;
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
        public CreateAuthorResponse Create(CreateAuthorRequest authorRequest)
        {
            IAuthorService authorService = IoC.Resolve<IAuthorService>();
            return authorService.CreateAuthor(authorRequest);
        }

        [Route("{authorId}/updateEmail")]
        [HttpPut()]
        [ResponseWrapper()]
        public void UpdateEmail(int authorId, [FromBody] string email)
        {
            UpdateAuthorEmailCommand updateAuthorEmail = new UpdateAuthorEmailCommand();
            updateAuthorEmail.AuthorId = authorId;
            updateAuthorEmail.Email = email;
            ICommandHandler<UpdateAuthorEmailCommand> command = IoC.Resolve<ICommandHandler<UpdateAuthorEmailCommand>>();
            command.Handle(updateAuthorEmail);
        }

        [Route("{authorId}/active")]
        [HttpPost()]
        [ResponseWrapper()]
        public void ActiveAuthor(int authorId)
        {
            ActiveAuthorRequest request = new ActiveAuthorRequest()
            {
                AuthorId = authorId
            };
            IAuthorService service = IoC.Resolve<IAuthorService>();
            service.ActiveAuthor(request);
        }
    }
}
