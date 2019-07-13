using System.Configuration;

namespace TinyERP.Common.Config
{
    public class Configuration : System.Configuration.ConfigurationSection
    {
        private static Configuration _instance;
        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (Configuration)System.Configuration.ConfigurationManager.GetSection("tinyErpConfiguration");

                }

                return _instance;
            }
        }
        [ConfigurationProperty("userManagement")]
        public UserManagementElement UserManagement
        {
            get
            {
                return (UserManagementElement)this["userManagement"];
            }
        }
        [ConfigurationProperty("databaseConnections")]
        [ConfigurationCollection(typeof(DatabaseConnectionsElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public DatabaseConnectionsElement DatabaseConnections
        {
            get
            {
                return (DatabaseConnectionsElement)this["databaseConnections"];
            }
        }
    }

}
