namespace TinyERP.Common.Attribute
{
    public class MinLength : BaseAttribute
    {
        public int MinLengthValue { get; private set; }
        public MinLength(int minLength, string messageKey): base(messageKey)
        {
            this.MinLengthValue = minLength;
        }
    }
}
