using System;
using System.Data.Entity;
using System.Linq;
using TinyERP.Common.Entities;

namespace TinyERP.Common.Repositories
{
    public abstract class BaseRepository<TEntity, IdType> where TEntity : BaseEntity<IdType>
         where IdType : IComparable<IdType>
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

        public BaseRepository(DbContext context, ContextMode mode)
        {
            this.dbSet = context.Set<TEntity>();
            this.mode = mode;
        }

        public TEntity Create(TEntity value)
        {
            this.dbSet.Add(value);
            return value;
        }


        public TEntity GetById(IdType id)
        {
            return this.AsQueryable.FirstOrDefault(item => item.Id.Equals(id));
        }
    }
}
