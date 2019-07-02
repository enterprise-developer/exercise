namespace REST.Common.Attribute
{
    using REST.Common.Data;
    using REST.Common.Validation;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ResponseData response = new ResponseData();
            if (actionExecutedContext.Exception != null && !(actionExecutedContext.Exception is ValidationException))
            {
                response.SetStatus(HttpStatusCode.InternalServerError);
            }
            if (actionExecutedContext.Exception != null && (actionExecutedContext.Exception is ValidationException))
            {
                ValidationException exception = actionExecutedContext.Exception as ValidationException;
                response.SetErrors(exception.Errors);
                response.SetStatus(HttpStatusCode.BadRequest);
            }
            if (actionExecutedContext.Exception == null && actionExecutedContext.Response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                ObjectContent content = (ObjectContent)actionExecutedContext.Response.Content;
                response.SetData(content.Value);
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, response);
        }
    }
}