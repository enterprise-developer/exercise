using TestERP.Common.IoC;
using TestERP.Common.Task;
using TestERP.Inventory.Respositories;
using TestERP.Inventory.Services;

namespace TestERP.Inventory
{
    public class Bootstrapper:IBootstrapper
    {
        public void Execute()
        {
            IoC.Container.RegisterAsSingleton<IProductService, ProductService>();
            IoC.Container.RegisterAsSingleton<IProductRespository, ProductRepository>();

        }
    }
}
