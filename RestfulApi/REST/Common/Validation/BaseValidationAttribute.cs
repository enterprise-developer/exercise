namespace REST.Common.Validation
{
    using System;
    public class BaseValidationAttribute : Attribute
    {
        public string ErrorKey { get; protected set; }

        public virtual bool IsValid(object val)
        {
            return true;
        }
    }
}