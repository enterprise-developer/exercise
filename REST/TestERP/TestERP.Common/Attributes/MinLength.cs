namespace TestERP.Common.Attributes
{
    public class MinLength: BaseAttribute
    {
        public int Min { get; set; }
        public MinLength(string messageKey, int min):base(messageKey)
        {
            this.Min = min;
        }

        public override bool IsValid(object item)
        {
            return item != null ? item.ToString().Length >= this.Min : false;
        }
    }
}
