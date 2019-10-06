using System.Collections.Generic;
using System.Linq;
using TestERP.Inventory.Context;
using TestERP.Inventory.Entity;

namespace TestERP.Inventory.Respositories
{
    public class ProductRepository : IProductRespository
    {
        public IList<Product> GetAll()
        {
            InventoryDbContext dbContext = new InventoryDbContext();
            return dbContext.Products.ToList();
        }
    }
}
