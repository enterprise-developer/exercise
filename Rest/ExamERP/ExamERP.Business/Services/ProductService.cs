using System.Collections.Generic;
using ExamERP.Business.Dto;
using ExamERP.Business.Entity;
using ExamERP.Business.Repositorties;
using ExamERP.Common.Exceptions;
using ExamERP.Common.Helpers;
using ExamERP.Common.IoC;

namespace ExamERP.Business.Services
{
    public class ProductService : IProductService
    {
        public Product AddProduct(CreateProductRequest productRequest)
        {
            Validation(productRequest);
            Product product = new Product()
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Quantity = productRequest.Quantity,
                Price = productRequest.Price
            };

            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            return repository.AddProduct(product);
        }

        public Product GetById(int id)
        {
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            return repository.GetById(id);
        }

        public IList<Product> GetProducts()
        {
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            return repository.GetAll();
        }

        private void Validation(CreateProductRequest productRequest)
        {
            List<string> messages = new List<string>();
            messages = ValidationHelper.GetMessages(productRequest);
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            Product product = repository.GetProductByName(productRequest.Name);
            if (product != null)
            {
                messages.Add("business.addNewProduct.nameWasExist");
            }

            if (messages.Count>0)
            {
                throw new ValidationException(messages);
            }
        }
    }
}
