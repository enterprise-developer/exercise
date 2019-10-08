using System.Collections.Generic;

namespace Product.Services
{
    public interface IProductService
    {
        IList<Product.Entity.Product> GetProducts();
    }
}
