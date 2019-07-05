using System.Data.Entity;

namespace TinyERP.Common.Common.Data
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(string connectionString) : base(connectionString)
        {

        }

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
    }
}
