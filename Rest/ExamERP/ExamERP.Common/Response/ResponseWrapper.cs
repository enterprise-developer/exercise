namespace ExamERP.Common.Response
{
    using ExamERP.Common.Exceptions;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    public class ResponseWrapper:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            ResponseData responseData = new ResponseData();
            if (context.Exception != null && context.Exception is IValidationException)
            {
                responseData.SetErrors(((IValidationException)context.Exception).Errors);
                responseData.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                responseData.StatusCode = HttpStatusCode.InternalServerError;
            }

            if (context.Exception == null && context.Response.StatusCode == HttpStatusCode.OK)
            {
                responseData.StatusCode = HttpStatusCode.OK;
            }
            if (context.Exception ==null  && context.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                ObjectContent objectContent = (ObjectContent)context.Response.Content;
                responseData.Data = objectContent.Value;
                responseData.StatusCode = HttpStatusCode.OK;
            }
            context.Response = context.Request.CreateResponse(responseData.StatusCode, responseData);
        }
    }
}
