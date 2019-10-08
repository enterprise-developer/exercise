namespace Product.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Product.Context;
    internal class ProductRepository : IProductRepository
    {
        public IList<Entity.Product> GetAlls()
        {
            ProductDbContext context = new ProductDbContext();
            return context.Products.ToList();
        }
    }
}
