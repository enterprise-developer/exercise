using Newtonsoft.Json;
using System;
using TinyERP.Common.DI;
using TinyERP.LoggerManagement.Entities;
using TinyERP.LoggerManagement.Repositories;

namespace TinyERP.LoggerManagement.Service
{
    public class LoggerService : ILoggerService
    {
        public void Create(Exception ex)
        {
            Log log = new Log()
            {
                CreatedDate = DateTime.Now,
                Message = JsonConvert.SerializeObject(ex)
            };
            ILoggerRepository repository = IoC.Resolve<ILoggerRepository>();
            repository.Create(log);
        }
    }
}
