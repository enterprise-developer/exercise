using TinyERP.Common.Repositories;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetByUserName(string userName);
    }
}
