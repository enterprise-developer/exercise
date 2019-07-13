using System.Configuration;

namespace TinyERP.Common.Config
{
    public class DatabaseConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }
        [ConfigurationProperty("server")]
        public string Server
        {
            get
            {
                return (string)this["server"];
            }
        }
        [ConfigurationProperty("database")]
        public string Database
        {
            get
            {
                return (string)this["database"];
            }
        }

        [ConfigurationProperty("userName")]
        public string UserName
        {
            get
            {
                return (string)this["userName"];
            }
        }
        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
        }
    }
}
