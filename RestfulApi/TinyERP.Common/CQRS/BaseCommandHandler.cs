using TinyERP.Common.Data.UoW;

namespace TinyERP.Common.CQRS
{
    public abstract class BaseCommandHandler
    {
        protected IUnitOfWork CreateUnitOfWork<TEntity>()
        {
            return UnitOfWorkFactory.Create<TEntity>();
        }
    }
}
