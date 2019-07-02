using System;
using TinyERP.Common.Common.Helper;

namespace TinyERP.Common.Data
{
    public class DbContextFactory
    {
        public static TDbContext Create<TDbContext>()
        {
            Type dbType = AssemblyHelper.GetType<TDbContext>();
            return AssemblyHelper.CreateInstance<TDbContext>(dbType);
        }
    }
}
