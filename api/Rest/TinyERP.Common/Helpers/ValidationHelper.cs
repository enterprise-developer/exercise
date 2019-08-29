using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyERP.Common.Attribute;

namespace TinyERP.Common.Helpers
{
    public static class ValidationHelper
    {
        public static List<string> GetMessageKey(object model)
        {
            List<string> errorMessages = new List<string>();
            IList<PropertyInfo> props = model.GetType().GetProperties();
            foreach (PropertyInfo prop in props) {
                IList<BaseAttribute> atrs = prop.GetCustomAttributes<BaseAttribute>().ToList();
                foreach (BaseAttribute atr in atrs) {
                    if (!atr.IsValid(prop.GetValue(model))) {
                        errorMessages.Add(atr.MessageKey);
                    }
                }
            }
            return errorMessages;
        }
    }
}
