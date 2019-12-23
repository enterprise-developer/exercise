namespace TinyERP.UserMangement.Context
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;
    using TinyERP.Common.Common.Helper;
    using TinyERP.UserMangement.Aggregate;
    public class UserDbContext : BaseDbContext, IUserDbContext
    {
        public IDbSet<UserAggregateRoot> Users { get; set; }
        public IDbSet<UserGroup> UserGroups { get; set; }
        // code, fluent configuration
        public UserDbContext() : base(DatabaseConnectionHelper.GetConnection<IUserDbContext>().ToString())
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }
    }
}