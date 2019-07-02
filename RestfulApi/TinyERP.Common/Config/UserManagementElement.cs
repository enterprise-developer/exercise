using System.Configuration;

namespace TinyERP.Common.Config
{
    public class UserManagementElement:System.Configuration.ConfigurationElement
    {
       [ConfigurationProperty("apiEndpoint")] 
        public string ApiEndpoint
        {
            get
            {
                return (string)this["apiEndpoint"];
            }
        }

        [ConfigurationProperty("intergrationMode")]
        public IntegrationModeType IntegrationMode
        {

            get
            {
                return (IntegrationModeType)this["intergrationMode"];
            }
        }

    }
}
