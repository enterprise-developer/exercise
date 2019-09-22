namespace ExamERP.Common.Exceptions
{
    public class ValidationExceptionError
    {
        public string ErrorKey { get; set; }
        public ValidationExceptionError(string messageKey)
        {
            this.ErrorKey = messageKey;
        }
    }
}
