
namespace TinyERP.UserMangement.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.UoW;
    using TinyERP.UserMangement.Aggregate;

    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base()
        {

        }

        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context)
        {

        }

        public User GetUserByUserName(string userName)
        {
            return this.DbSet.FirstOrDefault(user => user.UserName.Equals(userName));
        }

        public User GetUserDetail(int userId)
        {
            return this.DbSet.FirstOrDefault(user => user.Id == userId);
        }

        public IList<User> GetUsers()
        {
            return this.DbSet.ToList();
        }
    }
}
