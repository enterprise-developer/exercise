using System;
using System.Linq;
using TinyERP.Common.Contexts;
using TinyERP.Common.Entities;

namespace TinyERP.Common.Repositories
{
    public class BaseQueryRepository<TEntity> : BaseRepository<TEntity>, IBaseQueryRepository<TEntity> where TEntity : DenormalizedEntity
    {
        public BaseQueryRepository() : base()
        {

        }

        public BaseQueryRepository(IBaseContext context, ContextMode mode = ContextMode.Write) : base(context, mode)
        {

        }

        public TEntity GetByAggregateId(Guid id)
        {
            return this.dbSet.AsQueryable().FirstOrDefault(item => item.AggregateId == id);
        }
    }
}
