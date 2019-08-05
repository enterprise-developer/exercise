using Learning.Entity;
using System.Data.Entity;

namespace Learning.Context
{
    public class LearningDbContext : DbContext
    {
        public LearningDbContext() : base("LearningConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LearningDbContext>());
        }

        public IDbSet<Student> Students { get; set; }
    }
}
