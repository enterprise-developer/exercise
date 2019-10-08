namespace Application.Common.Attribute
{
    using Application.Common.Data;
    using Application.Common.Exceptions;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            ResponseData response = new ResponseData();
            if (context.Exception != null && context.Exception is IValidationException)
            {
                response.SetErrors(((IValidationException)context.Exception).Errors);
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            if (context.Exception == null && context.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                response.StatusCode = HttpStatusCode.OK;
            }
            if (context.Exception == null && context.Response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                ObjectContent dataObject = (ObjectContent)context.Response.Content;
                response.Data = dataObject.Value;
                response.StatusCode = HttpStatusCode.OK;
            }
            context.Response = context.Request.CreateResponse(response.StatusCode, response);
        }
    }
}
