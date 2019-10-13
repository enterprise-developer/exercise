namespace TestERP.Common.Exceptions
{
    public class ValidationExceptionError
    {
        public string ErrorKey { get; set; }
        public ValidationExceptionError(string mess)
        {
            this.ErrorKey = mess;
        }
    }
}
