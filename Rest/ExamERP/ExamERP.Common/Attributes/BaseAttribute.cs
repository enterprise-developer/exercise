namespace ExamERP.Common.Attributes
{
    using System;

    public class BaseAttribute : Attribute
    {
        public string MessageKey { get;private set; }
        public BaseAttribute(string messageKey)
        {
            this.MessageKey = messageKey;
        }

        public virtual bool IsValid(object value)
        {
            return false;
        }
    }
}
