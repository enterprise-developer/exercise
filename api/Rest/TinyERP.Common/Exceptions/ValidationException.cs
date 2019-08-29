using System.Collections.Generic;

namespace TinyERP.Common.Exceptions
{
    public class ValidationException : System.Exception, IValidationException
    {
        public IList<ExceptionErrorMessage> Errors { get; set; }
        public ValidationException(IList<string> errorKeys)
        {
            this.Errors = new List<ExceptionErrorMessage>();
            foreach (string errorKey in errorKeys) {
                this.Errors.Add(new ExceptionErrorMessage(errorKey));
            }
        }
    }
}
