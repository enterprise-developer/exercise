using System;
using System.Collections.Generic;

namespace TestERP.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationExceptionError> Errors { get; set; }
        public ValidationException(List<string> messages)
        {
            this.Errors = new List<ValidationExceptionError>();
            foreach (string mess in messages)
            {
                this.Errors.Add(new ValidationExceptionError(mess));
            }
        }
    }
}
