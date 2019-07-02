namespace REST.Common.Validation
{
    using System.Reflection;
    public class ValidationHelper
    {
        public static ValidationException Validate(object request, string nullErrorKey = "")
        {
            ValidationException validator = new ValidationException();
            if (request == null)
            {
                validator.Add(new ValidationError(nullErrorKey));
                return validator;
            }
            PropertyInfo[] properties = request.GetType().GetProperties();
            foreach (PropertyInfo pro in properties)
            {
                BaseValidationAttribute validationAttribute = pro.GetCustomAttribute<BaseValidationAttribute>(true);
                if (validationAttribute == null) { continue; }
                object val = pro.GetMethod.Invoke(request, new object[] { });
                if (validationAttribute.IsValid(val)) { continue; }
                validator.Add(new ValidationError(validationAttribute.ErrorKey));
            }
            return validator;
        }
    }
}