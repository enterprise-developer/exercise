namespace Product.Context
{
    using System.Data.Entity;
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("ProductConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductDbContext>());
        }

        public IDbSet<Product.Entity.Product> Products { get; set; }
    }
}
