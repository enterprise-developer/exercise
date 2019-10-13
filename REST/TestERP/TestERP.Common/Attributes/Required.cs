namespace TestERP.Common.Attributes
{
    public class Required : BaseAttribute
    {
        public Required(string messagekey) : base(messagekey)
        {

        }

        public override bool IsValid(object item)
        {
            return item != null ? !string.IsNullOrEmpty(item.ToString()) : false;
        }
    }
}
