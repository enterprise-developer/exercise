namespace ExamERP.Common.Attributes
{
    public class GEZero : BaseAttribute
    {
        public GEZero(string messageKey) : base(messageKey)
        {
        }

        public override bool IsValid(object value)
        {
            int.TryParse(value.ToString(), out int parseValue);
            return parseValue >= 0;
        }
    }
}
