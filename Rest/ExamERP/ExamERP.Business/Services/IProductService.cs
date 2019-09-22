using ExamERP.Business.Dto;
using ExamERP.Business.Entity;
using System.Collections.Generic;

namespace ExamERP.Business.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product AddProduct(CreateProductRequest productRequest);
        Product GetById(int id);
    }
}
