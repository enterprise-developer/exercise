using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestERP.Common.Attributes;

namespace TestERP.Common.Helpers
{
    public static class ValidationHelper
    {
        public static List<string> GetMessages(object item)
        {
            List<string> messages = new List<string>();
            IList<PropertyInfo> properties = item.GetType().GetProperties();
            foreach (PropertyInfo propertyInfor in properties)
            {
                IList<BaseAttribute> attrs = propertyInfor.GetCustomAttributes<BaseAttribute>().ToList();
                foreach (BaseAttribute baseAttribute  in attrs)
                {
                    if (!baseAttribute.IsValid(propertyInfor.GetValue(item)))
                    {
                        messages.Add(baseAttribute.ErrorKey);
                    }
                }
            }

            return messages;
        }
    }
}
