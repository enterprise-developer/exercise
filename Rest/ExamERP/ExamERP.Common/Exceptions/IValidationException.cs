using System.Collections.Generic;

namespace ExamERP.Common.Exceptions
{
   public interface IValidationException
    {
        IList<ValidationExceptionError> Errors { get; set; }
    }
}
