using System.Collections.Generic;
using TestERP.Inventory.Dto;
using TestERP.Inventory.Entity;

namespace TestERP.Inventory.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();

        Product AddProduct(CreateProductRequest productRequest);
    }
}
