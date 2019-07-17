namespace TinyERP.Common.Config
{
    using System.Configuration;
    public class ApplicationTaskElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }
        [ConfigurationProperty("enable", IsRequired = false, DefaultValue = true)]
        public bool Enable
        {
            get
            {
                return (bool)this["enable"];
            }
        }
    }
}
