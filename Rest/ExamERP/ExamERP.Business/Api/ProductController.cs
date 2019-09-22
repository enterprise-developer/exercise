namespace ExamERP.Business.Api
{
    using ExamERP.Business.Dto;
    using ExamERP.Business.Entity;
    using ExamERP.Business.Services;
    using ExamERP.Common.IoC;
    using ExamERP.Common.Response;
    using System.Collections.Generic;
    using System.Web.Http;
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [Route("")]
        [ResponseWrapper()]
        [HttpGet()]
        public IList<Product> GetProduct()
        {
            IProductService service = IoC.Container.Resolve<IProductService>();
            return service.GetProducts();
        }

        [Route("")]
        [ResponseWrapper()]
        [HttpPost()]
        public Product AddProduct(CreateProductRequest productRequest)
        {
            IProductService service = IoC.Container.Resolve<IProductService>();
            return service.AddProduct(productRequest);
        }

        [Route("/id")]
        [ResponseWrapper()]
        [HttpGet]
        public Product GetById(int id)
        {
            IProductService service = IoC.Container.Resolve<IProductService>();
            return service.GetById(id);
        }
    }
}
