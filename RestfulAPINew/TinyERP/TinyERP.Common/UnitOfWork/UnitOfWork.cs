using System;
using TinyERP.Common.Contexts;

namespace TinyERP.Common.UnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : class, IBaseContext, new()
    {
        public IBaseContext Context { get; set; }
        public UnitOfWork()
        {
            this.Context = new TDbContext();
        }
        public void Dispose()
        {
        }
        public void Commit()
        {
            this.Context.SaveChanges();
        }
    }
}
