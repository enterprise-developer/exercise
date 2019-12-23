namespace TinyERP.Common.Event
{
    using TinyERP.Common.Data.UoW;
    public abstract class BaseEventHandler
    {
        protected IUnitOfWork CreateUnitOfWork<TEntity>()
        {
            return UnitOfWorkFactory.Create<TEntity>();
        }
    }
}
