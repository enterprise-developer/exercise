using System;

namespace TestERP.Common.Attributes
{
    public class BaseAttribute : Attribute
    {
        public string ErrorKey { get; private set; }
        public BaseAttribute(string messageKey)
        {
            this.ErrorKey = messageKey;
        }

        public virtual bool IsValid(object value)
        {
            return false;
        }
    }
}
