namespace TinyERP.Common.Contexts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBaseContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
}
