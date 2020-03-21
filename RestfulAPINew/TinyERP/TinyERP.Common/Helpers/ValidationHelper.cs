namespace TinyERP.Common.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TinyERP.Common.Attributes;
    using TinyERP.Common.Vadations;

    public static class ValidationHelper
    {
        public static IList<Error> Validate(object request)
        {
            IList<Error> errors = new List<Error>();
            IList<PropertyInfo> props = request.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                IList<BaseAttribute> baseAttibutes = prop.GetCustomAttributes<BaseAttribute>().ToList();
                foreach (BaseAttribute attribute in baseAttibutes)
                {
                    bool isValid = attribute.IsValid(prop.GetValue(request));
                    if (!isValid)
                    {
                        errors.Add(new Error(attribute.ErrorKey));
                    }
                }
            }
            return errors;
        }
    }
}
