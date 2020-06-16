using System;
using TinyERP.Common.Contexts;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;

namespace TinyERP.Common.UnitOfWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork where TEntity : BaseEntity
    {
        public IBaseContext Context { get; set; }
        public UnitOfWork()
        {
            Type contextType = AssemblyHelper.GetDbContextType<TEntity>();
            this.Context = (IBaseContext)Activator.CreateInstance(contextType);
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
