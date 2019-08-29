using System.Collections.Generic;

namespace TinyERP.Common.Exceptions
{
    public interface IValidationException
    {
        IList<ExceptionErrorMessage> Errors { get; }
    }
}
