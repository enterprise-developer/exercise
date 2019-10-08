using Application.Common.Exceptions;
using System.Collections.Generic;
using System.Net;

namespace Application.Common.Data
{
    public class ResponseData
    {
        public IList<ExceptionErrorMessage> Errors { get; set; }
        public IList<ExceptionErrorMessage> SetErrors (IList<ExceptionErrorMessage> errorKeys){
            return this.Errors = errorKeys;
        }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
    }
}
