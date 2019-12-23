﻿namespace TinyERP.Common.CQRS
{
    using TinyERP.Common.Data.UoW;
    public abstract class BaseCommandHandler
    {
        protected IUnitOfWork CreateUnitOfWork<TEntity>()
        {
            return UnitOfWorkFactory.Create<TEntity>();
        }
    }
}
