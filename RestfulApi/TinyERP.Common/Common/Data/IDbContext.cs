namespace TinyERP.Common.Common.Data
{
    using System;
    using TinyERP.Common.Data;
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class;
        int SaveChanges();

    }
}
