using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class EndPoint : ConfigurationElement
    {
        [ConfigurationProperty("url")]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
        }
    }
}
