namespace TinyERP.Common.Common.Data
{
    using TinyERP.Common.Data;
    public abstract class BaseDbContext : System.Data.Entity.DbContext, IDbContext
    {
        public BaseDbContext(string connectionString) : base(connectionString)
        {

        }

        public IDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class
        {
            return new BaseDbSet<TEntity>(this, mode);
            //return this.Set<TEntity>();
        }
    }
}
