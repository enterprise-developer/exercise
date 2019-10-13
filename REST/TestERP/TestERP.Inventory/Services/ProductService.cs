using System.Collections.Generic;
using TestERP.Common.Exceptions;
using TestERP.Common.Helpers;
using TestERP.Common.IoC;
using TestERP.Inventory.Dto;
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

        public Product AddProduct(CreateProductRequest productRequest)
        {
            Validation(productRequest);
            IProductRespository respository = IoC.Container.Resolve<IProductRespository>();
            Product product = new Product()
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Description = productRequest.Description,
                Quantity = productRequest.Quantity
            };
            return respository.Add(product);
        }

        private void Validation(CreateProductRequest productRequest)
        {
            List<string> messages = ValidationHelper.GetMessages(productRequest);
            IProductRespository respository = IoC.Container.Resolve<IProductRespository>();
            Product product = respository.GetByName(productRequest.Name);
            if (product != null)
            {
                messages.Add("inventory.addNewProduct.nameWasExist");
            }

            if (messages.Count >0)
            {
                throw new ValidationException(messages);
            }
        }
    }
}
