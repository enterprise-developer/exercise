using System;
using System.Data.Entity;

namespace TinyERP.Common.Common.Data
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        int SaveChanges();

    }
}
