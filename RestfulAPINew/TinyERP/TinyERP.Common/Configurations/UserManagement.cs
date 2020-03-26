using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class UserManagement : ConfigurationElement
    {
        [ConfigurationProperty("mode")]
        public int Mode
        {
            get
            {
                return (int)this["mode"];
            }
        }
    }
}
