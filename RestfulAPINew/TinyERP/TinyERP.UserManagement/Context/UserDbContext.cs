using System.Data.Entity;
using TinyERP.Common.Helpers;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base(DatabaseConnectionHelper.GetConnection<UserDbContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}
