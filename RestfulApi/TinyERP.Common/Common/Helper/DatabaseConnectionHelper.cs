using TinyERP.Common.Config;
using TinyERP.Common.Data;
using TinyERP.Common.Exception;

namespace TinyERP.Common.Common.Helper
{
    public class DatabaseConnectionHelper
    {
        public static ConnectionString GetConnection<IDbType>()
        {
            string idbContextName = typeof(IDbType).FullName;
            DatabaseConnectionElement databaseConnection = Configuration.Instance.DatabaseConnections[idbContextName];
            if (databaseConnection == null) {
                throw new UnSupportException($"Can not found connection String to {idbContextName}");
            }
            return DatabaseConnectionFactory.Create(databaseConnection);
        }
    }
}
