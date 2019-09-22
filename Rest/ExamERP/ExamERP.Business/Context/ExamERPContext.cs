using ExamERP.Business.Entity;
using System.Data.Entity;

namespace ExamERP.Business.Context
{
    public class ExamERPContext : DbContext
    {
        public ExamERPContext() : base("ExamERPConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExamERPContext>());
        }

        public IDbSet<Product> Products { get; set; }
    }
}
