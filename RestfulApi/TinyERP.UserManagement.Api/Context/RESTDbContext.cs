namespace REST.Context
{
    using REST.Entity;
    using System.Data.Entity;
    public class RESTDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public RESTDbContext():base("RESTDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RESTDbContext>());
        }
    }
}