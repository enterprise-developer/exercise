using System.Data.Entity;
using System.Linq;

namespace TinyERP.Common.Databases
{
    public class TinyDbSet<TEntity> where TEntity : class
    {
        private DbSet<TEntity> dbSet;
        private ContextMode mode;
        public TinyDbSet(DbSet<TEntity> dbSet, ContextMode mode)
        {
            this.dbSet = dbSet;
            this.mode = mode;
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public IQueryable<TEntity> AsQueryable
        {
            get
            {
                if (this.mode == ContextMode.Read)
                {
                    return dbSet.AsNoTracking();
                }
                return dbSet;
            }
        }
    }
}
