namespace TinyERP.UserMangement.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.UoW;
    using TinyERP.UserMangement.Aggregate;

    internal class UserRepository : BaseRepository<UserAggregateRoot>, IUserRepository
    {
        public UserRepository() : base() { }

        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context) { }

        public UserAggregateRoot GetUserByUserName(string userName, int excludedUserId=0)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(user => (excludedUserId ==0 || user.Id!=excludedUserId) && user.UserName.Equals(userName));
        }

        public UserAggregateRoot GetUserDetail(int userId)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(user => user.Id == userId);
        }

        public IList<UserAggregateRoot> GetUsers()
        {
            return this.DbSet.AsQueryable().ToList();
        }
    }
}
