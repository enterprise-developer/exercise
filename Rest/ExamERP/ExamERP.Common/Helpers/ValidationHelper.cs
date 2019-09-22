using ExamERP.Common.Attributes;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace ExamERP.Common.Helpers
{
    public static class ValidationHelper
    {
        public static List<string> GetMessages(object model) {
            List<string> messages = new List<string>();
            IList<PropertyInfo> properties = model.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                IList<BaseAttribute> attrs = propertyInfo.GetCustomAttributes<BaseAttribute>().ToList();
                foreach (BaseAttribute baseAttribute in attrs)
                {
                    if (!baseAttribute.IsValid(propertyInfo.GetValue(model)))
                    {
                        messages.Add(baseAttribute.MessageKey);
                    }
                }
            }

            return messages;
        }
    }
}
