using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class ConnectionCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionElement)element).Name;
        }

        new public ConnectionElement this[string name]
        {
            get
            {
                return (ConnectionElement)BaseGet(name);
            }
        }
    }
}
