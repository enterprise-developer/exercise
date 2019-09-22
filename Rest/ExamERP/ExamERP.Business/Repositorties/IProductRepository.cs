using ExamERP.Business.Dto;
using ExamERP.Business.Entity;
using System.Collections.Generic;

namespace ExamERP.Business.Repositorties
{
    public interface IProductRepository
    {
        IList<Product> GetAll();

        Product GetProductByName(string name);

        Product AddProduct(Product request);

        Product GetById(int id);
    }
}
