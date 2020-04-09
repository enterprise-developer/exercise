using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Services
{
    public interface IUserService
    {
        int Create(CreateAuthorDto request);
        AuthorInfo GetAuthorInfo(int id);
    }
}
