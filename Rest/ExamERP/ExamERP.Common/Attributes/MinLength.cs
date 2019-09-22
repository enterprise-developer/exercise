namespace ExamERP.Common.Attributes
{
    public class MinLength : BaseAttribute
    {
        public int Min { get; set; }
        public MinLength(string messageKey, int minLength) : base(messageKey)
        {
            this.Min = minLength;
        }
        public override bool IsValid(object value)
        {
            return value.ToString().Length >= this.Min;
        }
    }
}
