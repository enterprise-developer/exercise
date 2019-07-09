using System;
using System.Data.Entity;
using TinyERP.Common.Data;

namespace TinyERP.Common.Common.Data
{
    public interface IDbContext : IDisposable
    {
        BaseDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class;
        int SaveChanges();

    }
}
