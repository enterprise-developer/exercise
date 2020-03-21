namespace TinyERP.Common.Attributes
{
    public class MaxLength : BaseAttribute
    {
        public MaxLength(string errorKey, int maxLength) : base(errorKey)
        {
            this.MaxLengthValue = maxLength;
        }
        public int MaxLengthValue { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            return value.ToString().Length <= this.MaxLengthValue;
        }
    }
}
