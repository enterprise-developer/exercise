using System;

namespace TestERP.Common.Attributes
{
    public class BaseAttribute: Attribute
    {
        public string ErrorKey { get; private set; }
        public BaseAttribute(string messagekey)
        {
            this.ErrorKey = messagekey;
        }

        public virtual bool IsValid(object item)
        {
            return false;
        }
    }
}
