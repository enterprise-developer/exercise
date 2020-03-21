namespace TinyERP.Common.Attributes
{
    public class MinLength : BaseAttribute
    {
        public MinLength(string errorKey, int minLength) : base(errorKey)
        {
            this.MinLengthValue = minLength;
        }
        public int MinLengthValue { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null) { return false; }
            return value.ToString().Length >= this.MinLengthValue;
        }
    }
}
