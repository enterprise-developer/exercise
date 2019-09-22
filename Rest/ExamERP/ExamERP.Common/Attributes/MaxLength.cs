namespace ExamERP.Common.Attributes
{
    public class MaxLength : BaseAttribute
    {
        public int Max { get; set; }
        public MaxLength(string messageKey, int maxLength) : base(messageKey)
        {
            this.Max = maxLength;
        }
        public override bool IsValid(object value)
        {
            return value.ToString().Length < this.Max;
        }
    }
}
