namespace TinyERP.Common.Attributes
{
    public class BaseAttribute : System.Attribute
    {
        public BaseAttribute(string errorKey)
        {
            this.ErrorKey = errorKey;
        }
        public string ErrorKey { get; private set; }
        public virtual bool IsValid(object value)
        {
            return false;
        }
    }
}
