using System;
using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class LoggerElement : ConfigurationElement
    {
        [ConfigurationProperty("type")]
        public ApplicationLoggerType Type
        {
            get
            {
                return (ApplicationLoggerType)Enum.Parse(typeof(ApplicationLoggerType), this["type"].ToString());
            }
        }

        [ConfigurationProperty("endPoint")]
        public EndPoint Endpoint
        {
            get
            {
                return (EndPoint)this["endPoint"];
            }
        }
    }
}
