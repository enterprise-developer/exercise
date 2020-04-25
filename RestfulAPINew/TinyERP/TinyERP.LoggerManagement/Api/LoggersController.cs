using System;
using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Responses;
using TinyERP.LoggerManagement.Service;

namespace TinyERP.LoggerManagement.Api
{
    [RoutePrefix("api/loggers")]
    public class LoggersController: ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public void Create(Exception ex)
        {
            ILoggerService service = IoC.Resolve<ILoggerService>();
            service.Create(ex);
        }
    }
}
