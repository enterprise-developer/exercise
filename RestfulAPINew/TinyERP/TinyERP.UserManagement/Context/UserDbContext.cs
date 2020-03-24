using System.Data.Entity;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("UserDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}
