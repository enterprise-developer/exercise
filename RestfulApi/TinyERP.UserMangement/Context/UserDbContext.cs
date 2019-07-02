namespace TinyERP.UserMangement.Context
{
    using System.Data.Entity;
    using TinyERP.UserMangement.Aggregate;
    public class UserDbContext : DbContext, IUserDbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserGroup> UserGroups { get; set; }
        public UserDbContext() : base("UserDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }
    }
}