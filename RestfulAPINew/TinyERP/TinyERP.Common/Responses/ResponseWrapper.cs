using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Responses
{
    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Response<object> response = new Response<object>();
            if (actionExecutedContext.Exception != null)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception is ValidationException)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Errors = (actionExecutedContext.Exception as ValidationException).Errors;
            }

            if (actionExecutedContext.Response != null && actionExecutedContext.Response.StatusCode != HttpStatusCode.NoContent)
            {
                response.Data = ((ObjectContent)actionExecutedContext.Response.Content).Value;
                response.StatusCode = HttpStatusCode.OK;
            }

            if (actionExecutedContext.Response != null && actionExecutedContext.Response.StatusCode == HttpStatusCode.NoContent)
            {
                response.StatusCode = HttpStatusCode.OK;
            }


            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
