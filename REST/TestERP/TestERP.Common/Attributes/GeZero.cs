namespace TestERP.Common.Attributes
{
    public class GeZero: BaseAttribute
    {
        public GeZero(string messageKey):base(messageKey)
        {

        }

        public override bool IsValid(object item)
        {
            if (item == null)
            {
                return false;
            }

            int.TryParse(item.ToString(), out int parsedItem);
            return parsedItem >= 0;
        }
    }
}
