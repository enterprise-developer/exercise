namespace TinyERP.Common.Data.UoW
{
    using TinyERP.Common.Common.Data;
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create<TEntity>()
        {
            IDbContext dbContext = DbContextFactory.CreateContext<TEntity>();
            if (dbContext == null)
            {
                throw new System.Exception("dbContext is null");
            }
            return new UnitOfWork(dbContext);
        }
    }
}
