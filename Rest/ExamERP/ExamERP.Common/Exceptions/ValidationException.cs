using System;
using System.Collections.Generic;

namespace ExamERP.Common.Exceptions
{
    public class ValidationException : Exception,IValidationException
    {
        public IList<ValidationExceptionError> Errors { get; set; }
        public ValidationException(List<string>messages)
        {
            this.Errors = new List<ValidationExceptionError>();
            foreach (string message in messages)
            {
                this.Errors.Add(new ValidationExceptionError(message));
            }
        }
    }
}
