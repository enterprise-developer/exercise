using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class ConfigurationApp : ConfigurationSection
    {
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
