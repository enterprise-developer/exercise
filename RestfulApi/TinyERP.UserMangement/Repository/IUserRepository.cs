
namespace TinyERP.UserMangement.Repository
{
    using System.Collections.Generic;
    using TinyERP.Common.Data;
    using TinyERP.UserMangement.Aggregate;

    public interface IUserRepository : IBaseRepository<User>
    {
        IList<User> GetUsers();
        User GetUserDetail(int userId);
        User GetUserByUserName(string userName);
        
    }
}
