using TinyERP.Common.Configurations;
using TinyERP.Common.Exceptions;

namespace TinyERP.Common.Helpers
{
    public class DatabaseConnectionHelper
    {
        public static string GetConnection<TContext>()
        {
            string connectionString;
            ConnectionElement connectionElement = ConfigurationApp.Instance.Connections[typeof(TContext).FullName];
            if (connectionElement == null)
            {
                throw new NotFoundException($"Cannot found config for connection of {typeof(TContext).FullName}");
            }
            connectionString = $"Data Source= {connectionElement.Server}; Initial Catalog= {connectionElement.DatabaseName}; User= {connectionElement.User}; Password= {connectionElement.Password};";
            return connectionString;
        }
    }
}
