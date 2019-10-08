namespace Product.Services
{
    using System.Collections.Generic;
    using Application.Common.IoC;
    using Product.Repositories;
    internal class ProductService : IProductService
    {
        public IList<Entity.Product> GetProducts()
        {
            IProductRepository repo = IoC.Container.Resolve<IProductRepository>();
            return repo.GetAlls();
        }
    }
}
