using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class ConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("server")]
        public string Server
        {
            get
            {
                return this["server"] as string;
            }
        }

        [ConfigurationProperty("databaseName")]
        public string DatabaseName
        {
            get
            {
                return this["databaseName"] as string;
            }
        }

        [ConfigurationProperty("user")]
        public string User
        {
            get
            {
                return this["user"] as string;
            }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {
                return this["password"] as string;
            }
        }

    }
}
