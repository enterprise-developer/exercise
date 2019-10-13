namespace TestERP.Common.Attributes
{
    public class MaxLength : BaseAttribute
    {
        public int Max { get; set; }
        public MaxLength(string messageKey, int max) : base(messageKey)
        {
            this.Max = max;
        }

        public override bool IsValid(object value)
        {
            return value != null ? value.ToString().Length <= this.Max : false;
        }
    }
}
