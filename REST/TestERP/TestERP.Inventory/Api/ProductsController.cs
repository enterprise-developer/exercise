using System.Collections.Generic;
using System.Web.Http;
using TestERP.Common.Attributes;
using TestERP.Common.IoC;
using TestERP.Inventory.Entity;
using TestERP.Inventory.Services;

namespace TestERP.Inventory.Api
{
    [RoutePrefix("api/products")]
    public class ProductsController:ApiController
    {
        [Route("")]
        [ResponseWrapper()]
        [HttpGet()]
        public IList<Product> GetProducts()
        {
            IProductService productService = IoC.Container.Resolve<IProductService>();
            return productService.GetProducts();
        }
    }
}
