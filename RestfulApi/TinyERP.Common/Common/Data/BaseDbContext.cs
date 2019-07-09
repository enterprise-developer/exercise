using System.Data.Entity;
using TinyERP.Common.Data;

namespace TinyERP.Common.Common.Data
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(string connectionString) : base(connectionString)
        {

        }

        public BaseDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class
        {
            return new BaseDbSet<TEntity>(this, mode);
            //return this.Set<TEntity>();
        }
    }
}
