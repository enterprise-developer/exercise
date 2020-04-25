using System.Data.Entity;
using TinyERP.Common.Helpers;
using TinyERP.LoggerManagement.Entities;

namespace TinyERP.LoggerManagement.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext() : base(DatabaseConnectionHelper.GetConnection<LogDbContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LogDbContext>());
        }

        public DbSet<Log> Logs { get; set; }
    }
}
