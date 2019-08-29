namespace TinyERP.Common.Exceptions
{
    public class ExceptionErrorMessage
    {
        public string ErrorKey { get; set; }
        public ExceptionErrorMessage(string errorKey)
        {
            this.ErrorKey = errorKey;
        }
    }
}
