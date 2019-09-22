using ExamERP.Common.Exceptions;
using System.Collections.Generic;
using System.Net;

namespace ExamERP.Common.Response
{
    public class ResponseData
    {
        public HttpStatusCode StatusCode { get; set; }

        public object Data { get; set; }

        public IList<ValidationExceptionError> Errors { get; set; }
        public void SetErrors(IList<ValidationExceptionError> errors)
        {
            this.Errors = errors;
        }
    }
}
