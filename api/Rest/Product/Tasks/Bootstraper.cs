namespace Product.Tasks
{
    using Application.Common.IoC;
    using Application.Common.Tasks;
    using Product.Repositories;
    using Product.Services;
    public class Bootstraper : IBootstraper
    {
        public void Execute()
        {
            IoC.Container.RegisterAsSingleton<IProductService, ProductService>();
            IoC.Container.RegisterAsSingleton<IProductRepository, ProductRepository>();
        }
    }
}
