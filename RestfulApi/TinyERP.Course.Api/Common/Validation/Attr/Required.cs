namespace REST.Common.Validation.Attr
{
    public class Required : BaseValidationAttribute
    {
        public Required(string errorKey)
        {
            this.ErrorKey = errorKey;
        }

        public override bool IsValid(object val)
        {
            if (val is string && !string.IsNullOrWhiteSpace(val as string))
            {
                return true;
            }
            return false;
        }
    }
}