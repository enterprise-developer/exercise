using System.Collections.Generic;
using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class ConfigurationApp : ConfigurationSection
    {
        private  static ConfigurationApp configuration;
        public static ConfigurationApp Instance
        {
            get
            {
                if (ConfigurationApp.configuration == null)
                {
                    ConfigurationApp.configuration = ConfigurationManager.GetSection("appConfig") as ConfigurationApp;
                }
                return ConfigurationApp.configuration;
            }
        }

        [ConfigurationProperty("userManagement")]
        public UserManagement UserManagement
        {
            get
            {
                return (UserManagement)this["userManagement"];
            }
        }

        [ConfigurationProperty("connections")]
        [ConfigurationCollection(typeof(ConnectionCollection), AddItemName ="add", ClearItemsName ="clear", RemoveItemName ="remove")]
        public ConnectionCollection Connections
        {
            get
            {
                ConnectionCollection connections = (ConnectionCollection)base["connections"];
                return connections;
            }
        }
    }
}
