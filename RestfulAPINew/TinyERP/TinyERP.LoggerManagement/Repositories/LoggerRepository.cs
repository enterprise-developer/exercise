using TinyERP.Common;
using TinyERP.Common.Repositories;
using TinyERP.LoggerManagement.Context;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Repositories
{
    public class LoggerRepository : BaseRepository<Log>, ILoggerRepository
    {
        public LoggerRepository(LogDbContext context, ContextMode contextMode = ContextMode.Write) : base(context, contextMode)
        {
        }

        public LoggerRepository() : base()
        {
        }
    }
}
