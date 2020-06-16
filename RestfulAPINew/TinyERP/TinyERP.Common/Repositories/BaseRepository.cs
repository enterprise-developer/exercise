using System.Data.Entity;
using System.Linq;
using TinyERP.Common.Contexts;
using TinyERP.Common.Entities;

namespace TinyERP.Common.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private ContextMode mode;
        private IDbSet<TEntity> dbSet;
        protected IQueryable<TEntity> AsQueryable
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

        public BaseRepository(IBaseContext context, ContextMode mode)
        {
            this.dbSet = context.Set<TEntity>();
            this.mode = mode;
        }

        public TEntity Create(TEntity value)
        {
            this.dbSet.Add(value);
            return value;
        }


        public TEntity GetById(int id)
        {
            return this.AsQueryable.FirstOrDefault(item => item.Id.Equals(id));
        }
    }
}
