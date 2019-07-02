namespace REST.Common.Validation
{
    using System;
    using System.Collections.Generic;

    public class ValidationException : Exception
    {
        public IList<ValidationError> Errors { get; private set; }
        public ValidationException() : base()
        {
            this.Errors = new List<ValidationError>();
        }

        public void Add(ValidationError error)
        {
            this.Errors.Add(error);
        }

        public void ThrowIfError()
        {
            if (this.Errors.Count == 0) { return; }
            throw this;
        }
    }
}