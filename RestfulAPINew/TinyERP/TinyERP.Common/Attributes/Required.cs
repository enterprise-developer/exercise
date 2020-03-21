namespace TinyERP.Common.Attributes
{
    public class Required : BaseAttribute
    {
        public Required(string errorKey): base(errorKey)
        {
        }
        public override bool IsValid(object value)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }
    }
}
