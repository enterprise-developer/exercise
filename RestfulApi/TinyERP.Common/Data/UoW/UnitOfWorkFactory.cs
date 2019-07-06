using System;
using TinyERP.Common.Common.Data;

namespace TinyERP.Common.Data.UoW
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create<TEntity>()
        {
            IDbContext dbContext = DbContextFactory.CreateContext<TEntity>();
            if (dbContext == null)
            {
                throw new Exception("dbContext is null");
            }
            return new UnitOfWork(dbContext);
        }
    }
}
