using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using TestERP.Common.Exceptions;
using TestERP.Common.Response;

namespace TestERP.Common.Attributes
{
    public class ResponseWrapper:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            ResponseData response = new ResponseData();
            if (context.Exception !=null && context.Exception is ValidationException)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            if (context.Exception != null)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            if (context.Exception == null && context.Response.StatusCode == HttpStatusCode.NoContent)
            {
                response.StatusCode = HttpStatusCode.OK;
            }
            if (context.Exception == null && context.Response.StatusCode!= HttpStatusCode.NoContent )
            {
                response.StatusCode = HttpStatusCode.OK;
                ObjectContent content = (ObjectContent)context.Response.Content;
                response.Data = content;
            }

            context.Response = context.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
