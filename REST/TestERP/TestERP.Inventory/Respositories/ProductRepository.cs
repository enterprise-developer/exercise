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

        public Product GetByName(string name)
        {
            InventoryDbContext dbContext = new InventoryDbContext();
            return dbContext.Products.FirstOrDefault(item => item.Name.Equals(name));
        }

        public Product Add(Product item)
        {
            InventoryDbContext dbContext = new InventoryDbContext();
            dbContext.Products.Add(item);
            dbContext.SaveChanges();
            return item;
        }
    }
}
