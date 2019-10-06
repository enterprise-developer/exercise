using System.Net;

namespace TestERP.Common.Response
{
    public class ResponseData
    {
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
    }
}
