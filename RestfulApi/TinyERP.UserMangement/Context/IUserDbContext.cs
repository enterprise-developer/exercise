namespace TinyERP.UserMangement.Context
{
    using System.Data.Entity;
    using TinyERP.UserMangement.Aggregate;
    public interface IUserDbContext
    {
        IDbSet<User> Users { get; }
        IDbSet<UserGroup> UserGroups { get; }
        int SaveChanges();
    }
}
