namespace Application.Common.Exceptions
{
    using System.Collections.Generic;
    public interface IValidationException
    {
        IList<ExceptionErrorMessage> Errors { get; }
    }
}
