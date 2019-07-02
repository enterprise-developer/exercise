using TinyERP.UserManagement.Share.Dto;

namespace TinyERP.UserManagement.Share.Facade
{
    public interface IUserManagementFacade
    {
        int CreateUserIfNotExisted(CreateUserRequest createUserRequest);
    }
}
