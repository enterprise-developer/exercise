using System.Configuration;

namespace TinyERP.Common.Config
{
    public class DatabaseConnectionsElement : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DatabaseConnectionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseConnectionElement)element).Name;
        }

        public new DatabaseConnectionElement this[string name]
        {
            get
            {
                return (DatabaseConnectionElement)this.BaseGet(name);
            }
        }
    }
}
