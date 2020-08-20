using System;
using System.Data.Entity;
using System.Linq;
using TinyERP.Common.Contexts;
using TinyERP.Common.Databases;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;

namespace TinyERP.Common.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public TinyDbSet<TEntity> dbSet;
        private IBaseContext baseContext;

        public BaseRepository(IBaseContext context, ContextMode mode)
        {
            this.dbSet = new TinyDbSet<TEntity>(context.Set<TEntity>(), mode);
            this.baseContext = context;
        }

        public BaseRepository()
        {
            Type type = AssemblyHelper.GetDbContextType<TEntity>();
            this.baseContext = (IBaseContext)Activator.CreateInstance(type);
            this.dbSet = new TinyDbSet<TEntity>(this.baseContext.Set<TEntity>(), ContextMode.Read);
        }

        public TEntity Create(TEntity value)
        {
            this.dbSet.Add(value);
            return value;
        }


        public TEntity GetById(Guid id, string include = "")
        {
            return this.dbSet.AsQueryable(include).FirstOrDefault(item => item.Id.Equals(id));
        }

        public void Update(TEntity entity)
        {
            this.baseContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
