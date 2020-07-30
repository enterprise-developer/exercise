using System.Web.Http;
using TinyERP.AuthorManagement.Dtos;
using TinyERP.AuthorManagement.Services;
using TinyERP.Common.DI;
using TinyERP.Common.Responses;

namespace TinyERP.AuthorManagement.Api
{
    [RoutePrefix("api/authors")]
    public class AuthorsController: ApiController
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
        public UpdateAuthorEmailResponse UpdateEmail(int authorId, [FromBody]string email)
        {
            UpdateAuthorEmailRequest updateAuthorEmail = new UpdateAuthorEmailRequest();
            updateAuthorEmail.AuthorId = authorId;
            updateAuthorEmail.Email = email;
            IAuthorService authorService = IoC.Resolve<IAuthorService>();
            return authorService.UpdateEmail(updateAuthorEmail);
        }
    }
}
