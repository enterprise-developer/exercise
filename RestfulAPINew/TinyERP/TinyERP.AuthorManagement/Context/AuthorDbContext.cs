using System.Data.Entity;
using TinyERP.AuthorManagement.Entities;
using TinyERP.Common.Contexts;
using TinyERP.Common.Helpers;

namespace TinyERP.AuthorManagement.Context
{
    public class AuthorDbContext: DbContext, IBaseContext
    {
        public AuthorDbContext(): base(DatabaseConnectionHelper.GetConnection<AuthorDbContext>())
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AuthorDbContext>());
        }

        public DbSet<AuthorAggregateRoot> Authors{ get; set; }
    }
}
