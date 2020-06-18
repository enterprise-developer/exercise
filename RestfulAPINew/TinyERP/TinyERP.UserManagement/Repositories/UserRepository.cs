using System.Linq;
using TinyERP.Common;
using TinyERP.Common.Repositories;
using TinyERP.UserManagement.Context;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context, ContextMode contextMode = ContextMode.Write) : base(context, contextMode)
        {
        }

        public UserRepository(): base()
        {

        }

        public User GetByUserName(string userName)
        {
            return this.AsQueryable.FirstOrDefault(item => item.UserName.Equals(userName));
        }
    }
}
