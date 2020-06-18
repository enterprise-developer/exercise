namespace TinyERP.Common.Contexts
{
    using System.Data.Entity;
    public interface IBaseContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
