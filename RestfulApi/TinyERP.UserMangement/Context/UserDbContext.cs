namespace TinyERP.UserMangement.Context
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;
    using TinyERP.UserMangement.Aggregate;
    public class UserDbContext : BaseDbContext, IUserDbContext
    {
        public IDbSet<UserAggregateRoot> Users { get; set; }
        public IDbSet<UserGroup> UserGroups { get; set; }
        public UserDbContext() : base("UserDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }
    }
}