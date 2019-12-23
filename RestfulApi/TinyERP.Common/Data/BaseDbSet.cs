namespace TinyERP.Common.Data
{
    using System.Data.Entity;
    using System.Linq;
    using TinyERP.Common.Exception;
    public class BaseDbSet<TEntity>: IDbSet<TEntity> where TEntity : class
    {
        private DbContext dbContext;
        private IOMode mode;
        private System.Data.Entity.IDbSet<TEntity> dbSet;
        public BaseDbSet(DbContext dbContext, IOMode mode)
        {
            this.dbContext = dbContext;
            this.mode = mode;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (this.mode == IOMode.ReadOnly)
            {
                throw new UnSupportException(string.Format("invalid mode:{0}", mode));
            }

            this.dbSet.Add(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return mode == IOMode.ReadOnly ? this.dbSet.AsNoTracking<TEntity>() : this.dbSet;
        }
    }
}
