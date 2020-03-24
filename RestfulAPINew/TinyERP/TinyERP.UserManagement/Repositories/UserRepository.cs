using System.Linq;
using TinyERP.UserManagement.Context;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDbContext context;
        public UserRepository()
        {
            this.context = new UserDbContext();
        }
        public User GetByUserName(string userName)
        {
            return this.context.Users.FirstOrDefault(item => item.UserName.Equals(userName));
        }

        public User Create(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
            return user;
        }
    }
}
