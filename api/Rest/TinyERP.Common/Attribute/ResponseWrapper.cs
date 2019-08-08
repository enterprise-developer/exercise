namespace TinyERP.Common.Attribute
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using TinyERP.Common.Exceptions;
    using TinyERP.Common.Response;

    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            ResponseData response = new ResponseData();
            if (context.Exception != null && context.Exception is IValidationException)
            {
                response.SetErrors(((IValidationException)context.Exception).Errors);
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            else {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            if (context.Exception == null && context.Response.StatusCode == HttpStatusCode.NoContent)
            {
                response.StatusCode = HttpStatusCode.OK;
            }
            if (context.Exception == null && context.Response.StatusCode != HttpStatusCode.NoContent)
            {
                ObjectContent dataObject = (ObjectContent)context.Response.Content;
                response.Data = dataObject.Value;
                response.StatusCode = HttpStatusCode.OK;
            }
            context.Response = context.Request.CreateResponse(response.StatusCode, response);
        }
    }
}
