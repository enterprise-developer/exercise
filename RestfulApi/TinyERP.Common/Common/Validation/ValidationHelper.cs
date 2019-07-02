namespace TinyERP.Common.Common.Validation
{
    using System.Reflection;
    public class ValidationHelper
    {
        public static ValidationException Validate(object request, string nullErrorKey = "")
        {
            ValidationException validation = new ValidationException();
            if (request == null)
            {
                validation.Add(new ValidationError(nullErrorKey));
                return validation;
            }
            PropertyInfo[] pros = request.GetType().GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                BaseValidationAttribute validationAttribute = pro.GetCustomAttribute<BaseValidationAttribute>(true);
                if (validationAttribute == null) { continue; }
                object val = pro.GetMethod.Invoke(request, new object[] { });
                if (validationAttribute.IsValid(val)) { continue; }
                validation.Add(new ValidationError(validationAttribute.ErrorKey));
            }
            return validation;
        }
    }
}