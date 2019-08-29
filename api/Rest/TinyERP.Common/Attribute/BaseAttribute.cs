namespace TinyERP.Common.Attribute
{
    public class BaseAttribute : System.Attribute
    {
        public string MessageKey { get; private set; }
        public BaseAttribute(string messageKey)
        {
            this.MessageKey = messageKey;
        }

        public bool IsValid(object value) {
            return false;
        }
    }
}
