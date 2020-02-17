using System.Collections.Generic;
using System.Net;
using TinyERP.Common.Vadations;

namespace TinyERP.Common.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public IList<Error> Errors{ get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
