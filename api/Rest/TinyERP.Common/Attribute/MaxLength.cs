namespace TinyERP.Common.Attribute
{
    public class MaxLength : BaseAttribute
    {
        public int MaxLengthValue { get; private set; }
        public MaxLength(int maxLengthValue, string messageKey): base(messageKey)
        {
            this.MaxLengthValue = maxLengthValue;
        }
    }
}
