using System.Data.Entity;
using System.Linq;
using TinyERP.Common;
using TinyERP.LoggerManagement.Context;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Repositories
{
    public class LoggerRepository: ILoggerRepository
    {
        private LogDbContext context;
        private ContextMode mode;
        private readonly IDbSet<Log> dbSet;
        protected IQueryable<Log> AsQueryable
        {
            get
            {
                if (this.mode == ContextMode.Read)
                {
                    return dbSet.AsNoTracking();
                }
                return dbSet;
            }
        }
        public LoggerRepository(LogDbContext context, ContextMode contextMode = ContextMode.Write)
        {
            this.context = context;
            this.mode = contextMode;
            this.dbSet = this.context.Logs;
        }

        public LoggerRepository() : this(new LogDbContext(), ContextMode.Read)
        {
        }

        public void Create(Log log)
        {
            this.context.Logs.Add(log);
            this.context.SaveChanges();
        }
    }
}
