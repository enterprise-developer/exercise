using System.Collections.Generic;
using TestERP.Common.IoC;
using TestERP.Inventory.Entity;
using TestERP.Inventory.Respositories;

namespace TestERP.Inventory.Services
{
    public class ProductService: IProductService
    {

        public IList<Product> GetProducts()
        {
            IProductRespository respository = IoC.Container.Resolve<IProductRespository>();
            return respository.GetAll();
        }
    }
}
