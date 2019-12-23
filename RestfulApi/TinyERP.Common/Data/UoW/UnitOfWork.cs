namespace TinyERP.Common.Data.UoW
{
    using TinyERP.Common.Common.Data;
    internal class UnitOfWork : IUnitOfWork
    {
        public IDbContext Context { get; private set; }
        public UnitOfWork(IDbContext dbContext)
        {
            this.Context = dbContext;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }
    }
}