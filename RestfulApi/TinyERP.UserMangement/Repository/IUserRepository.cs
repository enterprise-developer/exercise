
namespace TinyERP.UserMangement.Repository
{
    using System.Collections.Generic;
    using TinyERP.Common.Data;
    using TinyERP.UserMangement.Aggregate;

    public interface IUserRepository : IBaseRepository<UserAggregateRoot>
    {
        IList<UserAggregateRoot> GetUsers();
        UserAggregateRoot GetUserDetail(int userId);
        UserAggregateRoot GetUserByUserName(string userName, int excludedUserId=0);
        
    }
}
