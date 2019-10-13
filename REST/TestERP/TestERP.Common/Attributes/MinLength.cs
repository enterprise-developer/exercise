namespace TestERP.Common.Attributes
{
    public class MinLength : BaseAttribute
    {
        public int Min { get; set; }
        public MinLength(string messageKey, int min):base(messageKey)
        {
            this.Min = min;
        }

        public override bool IsValid(object value)
        {
            return value != null ? value.ToString().Length >= this.Min : false;
        }
    }
}
