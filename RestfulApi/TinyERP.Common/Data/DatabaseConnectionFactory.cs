using TinyERP.Common.Config;

namespace TinyERP.Common.Data
{
    public class DatabaseConnectionFactory
    {
        public static ConnectionString Create(DatabaseConnectionElement databaseConnection)
        {
            return new ConnectionString(databaseConnection);
        }
    }
}
