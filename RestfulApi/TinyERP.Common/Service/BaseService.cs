using TinyERP.Common.Data.UoW;

namespace TinyERP.Common.Service
{
    public abstract class BaseService
    {

        protected IUnitOfWork CreateUnitOfWork<TEntity>()
        {
            return UnitOfWorkFactory.Create<TEntity>();
        }
    }
}
