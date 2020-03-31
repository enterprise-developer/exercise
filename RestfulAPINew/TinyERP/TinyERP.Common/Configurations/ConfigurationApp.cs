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
    }
}
