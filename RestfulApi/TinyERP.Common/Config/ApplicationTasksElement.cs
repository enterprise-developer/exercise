using System.Configuration;

namespace TinyERP.Common.Config
{
    public class ApplicationTasksElement : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ApplicationTaskElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApplicationTaskElement)element).Name;
        }
        public new ApplicationTaskElement this[string name] {
            get {
                return (ApplicationTaskElement)this.BaseGet(name);
            }
        }
    }
}
