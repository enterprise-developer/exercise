using System.Data.Entity;
using System.Linq;
using TinyERP.Common;
using TinyERP.UserManagement.Context;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDbContext context;
        private ContextMode mode;
        private readonly IDbSet<User> dbSet;
        protected IQueryable<User> AsQueryable
        {
            get
            {
                if (this.mode == ContextMode.Read)
                {
                    return dbSet.AsNoTracking();
                }
                return dbSet;
            }
        }
        public UserRepository(UserDbContext context, ContextMode contextMode = ContextMode.Write)
        {
            this.context = context;
            this.mode = contextMode;
            this.dbSet = this.context.Users;
        }

        public UserRepository() : this(new UserDbContext(), ContextMode.Read)
        {
        }

        public User GetByUserName(string userName)
        {
            return this.AsQueryable.FirstOrDefault(item => item.UserName.Equals(userName));
        }

        public User Create(User user)
        {
            this.context.Users.Add(user);
            return user;
        }
        public User GetById(int id)
        {
            return this.AsQueryable.FirstOrDefault(x => x.Id == id);
        }
    }
}
