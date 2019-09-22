using ExamERP.Business.Repositorties;
using ExamERP.Business.Services;
using ExamERP.Common.IoC;
using ExamERP.Common.Task;

namespace ExamERP.Business.Task
{
    public class Bootstrapper : IBootstrapper
    {
        public void Execute()
        {
            IoC.Container.RegisterAsSingleton<IProductService, ProductService>();
            IoC.Container.RegisterAsSingleton<IProductRepository, ProductRespository>();
        }
    }
}
