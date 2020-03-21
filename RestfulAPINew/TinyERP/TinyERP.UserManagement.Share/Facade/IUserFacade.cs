using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public interface IUserFacade
    {
        int CreateIfNotExist(CreateAuthorDto createAuthor);
    }
}
