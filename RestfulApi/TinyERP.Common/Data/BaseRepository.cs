namespace TinyERP.Common.Data
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private IDbContext dbContext;
        protected BaseDbSet<TEntity> DbSet { get; private set; }
        public BaseRepository() : this(DbContextFactory.CreateContext<TEntity>(), IOMode.ReadOnly)
        {
        }

        public BaseRepository(IDbContext dbContext, IOMode mode = IOMode.Write)
        {
            this.DbSet = dbContext.GetDbSet<TEntity>(mode);
            this.dbContext = dbContext;
        }

        private static IDbContext CreateDbContext<IDbContextType>() where IDbContextType : IDbContext
        {
            return DbContextFactory.Create<IDbContextType>();
        }

        public void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            // this.DbSet.Update(entity);
        }
    }
}
