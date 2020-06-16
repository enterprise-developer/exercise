namespace TinyERP.Common.Contexts
{
    using System.Data.Entity;
    using TinyERP.Common.Entities;
    public interface IBaseContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
