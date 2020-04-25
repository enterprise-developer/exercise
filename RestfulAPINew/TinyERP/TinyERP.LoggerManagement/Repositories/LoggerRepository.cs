using System.Threading.Tasks;
using TinyERP.LoggerManagement.Context;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Repositories
{
    public class LoggerRepository: ILoggerRepository
    {
        private LogDbContext context;
        public LoggerRepository()
        {
            this.context = new LogDbContext();
        }
        public void Create(Log log)
        {
            this.context.Logs.Add(log);
            this.context.SaveChanges();
        }
    }
}
