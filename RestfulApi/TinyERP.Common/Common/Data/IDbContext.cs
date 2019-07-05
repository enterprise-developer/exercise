using System.Data.Entity;

namespace TinyERP.Common.Common.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity: class;
    }
}
