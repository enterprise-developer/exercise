using System;
using System.Reflection;
using TinyERP.Common.Attribute;
using TinyERP.Common.Common.Data;
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

        public static IDbContext CreateContext<TEntity>()
        {
            DbContextAttribute dbContextAttribute = ObjectHelper.GetAttribute<DbContextAttribute>(typeof(TEntity));
            if (dbContextAttribute == null || dbContextAttribute.Use == null)
            {
                throw new Exception("DbContext not exist!!!");
            }
            MethodInfo createMethod = typeof(DbContextFactory).GetMethod("Create", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public);
            MethodInfo genericMethod = createMethod.MakeGenericMethod(new[] { dbContextAttribute.Use });
            IDbContext dbContext = (IDbContext)genericMethod.Invoke(null, new object[] { });

            return dbContext;
        }
    }
}
