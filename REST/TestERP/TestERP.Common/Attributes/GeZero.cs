namespace TestERP.Common.Attributes
{
    public class GeZero : BaseAttribute
    {
        public GeZero(string messageKey) : base(messageKey)
        {

        }

        public virtual bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            int.TryParse(value.ToString(), out int newValue);
            return newValue >= 0;
        }
    }
}
