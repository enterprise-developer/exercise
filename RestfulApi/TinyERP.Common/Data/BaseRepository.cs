namespace TinyERP.Common.Data
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> DbSet { get; private set; }
        public BaseRepository() : this(DbContextFactory.CreateContext<TEntity>())
        {
        }

        public BaseRepository(IDbContext dbContext)
        {
            this.DbSet = dbContext.GetDbSet<TEntity>();
        }

        private static IDbContext CreateDbContext<IDbContextType>() where IDbContextType : IDbContext
        {
            return DbContextFactory.Create<IDbContextType>();
        }

        public void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }
    }
}
