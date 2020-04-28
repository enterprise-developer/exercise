using System;
using TinyERP.Common.Contexts;

namespace TinyERP.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseContext Context { get; set; }
        void Commit();
    }
}
