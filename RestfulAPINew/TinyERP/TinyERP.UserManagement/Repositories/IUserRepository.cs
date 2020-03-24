using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);

        User Create(User user);
    }
}
