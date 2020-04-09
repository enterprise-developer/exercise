namespace TinyERP.Common.Validations
{
    using System.Collections.Generic;
    using TinyERP.Common.Vadations;
    public class ValidationException : System.Exception
    {
        public ValidationException(IList<Error> errors)
        {
            this.Errors = errors;
        }
        public ValidationException(string errorKey) : this(new List<Error>() { new Error(errorKey) }) { }
        public IList<Error> Errors { get; set; }
    }
}
