using System.Data.Entity;
using System.Linq;
using TinyERP.Common;
using TinyERP.Common.Repositories;
using TinyERP.UserManagement.Context;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(UserDbContext context, ContextMode contextMode = ContextMode.Write) : base(context, contextMode)
        {
        }

        public UserRepository() : base(new UserDbContext(), ContextMode.Read)
        {
        }

        public User GetByUserName(string userName)
        {
            return this.AsQueryable.FirstOrDefault(item => item.UserName.Equals(userName));
        }
    }
}
