namespace TinyERP.Common.Data
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;

    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> DbSet { get; private set; }
        public BaseRepository()
        {

            // IDbContext  dbContext = this.Create
            IDbContext dbContext = DbContextFactory.CreateContext<TEntity>();
            this.DbSet = dbContext.GetDbSet<TEntity>();
        }

        private static IDbContext CreateDbContext<IDbContextType>() where IDbContextType : IDbContext
        {
            return DbContextFactory.Create<IDbContextType>();
        }
    }
}
