using TinyERP.AuthorManagement.Dtos;

namespace TinyERP.AuthorManagement.Services
{
    public interface IAuthorService
    {
        CreateAuthorResponse CreateAuthor(CreateAuthorRequest authorRequest);
        UpdateAuthorEmailResponse UpdateEmail(UpdateAuthorEmailRequest authorEmailRequest);
        void ActiveAuthor(ActiveAuthorRequest request);
    }
}
