using TinyERP.AuthorManagement.Commands;
using TinyERP.AuthorManagement.Dtos;

namespace TinyERP.AuthorManagement.Services
{
    public interface IAuthorService
    {
        CreateAuthorResponse CreateAuthor(CreateAuthorRequest authorRequest);
        UpdateAuthorEmailResponse UpdateEmail(UpdateAuthorEmailCommand authorEmailRequest);
        void ActiveAuthor(ActiveAuthorRequest request);
    }
}
