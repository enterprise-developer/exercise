namespace Product.Api
{
    using Application.Common.Attribute;
    using Application.Common.IoC;
    using Product.Services;
    using System.Collections.Generic;
    using System.Web.Http;
    [RoutePrefix("api/inventory/products")]
    public class ProductsController : ApiController
    {
        [Route("")]
        [HttpGet()]
        [ResponseWrapper()]
        public IList<Entity.Product> GetProducts()
        {
            IProductService service = IoC.Container.Resolve<IProductService>();
            return service.GetProducts();
        }
    }
}
