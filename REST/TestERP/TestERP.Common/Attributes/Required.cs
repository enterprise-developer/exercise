namespace TestERP.Common.Attributes
{
    public class Required : BaseAttribute
    {
        public Required(string messageKey) : base(messageKey)
        {

        }

        public override bool IsValid(object value)
        {
            return value != null ? string.IsNullOrEmpty(value.ToString()) : false;
        }
    }
}
