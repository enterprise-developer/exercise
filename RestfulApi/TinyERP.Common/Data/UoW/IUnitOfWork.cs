using System;
using TinyERP.Common.Common.Data;

namespace TinyERP.Common.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }

        void Commit();
    }
}
