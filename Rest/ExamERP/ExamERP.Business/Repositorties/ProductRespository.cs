using System.Collections.Generic;
using System.Linq;
using ExamERP.Business.Context;
using ExamERP.Business.Entity;

namespace ExamERP.Business.Repositorties
{
    public class ProductRespository : IProductRepository
    {
        public Product AddProduct(Product request)
        {
            ExamERPContext context = new ExamERPContext();
            context.Products.Add(request);
            context.SaveChanges();
            return request;
        }

        public IList<Product> GetAll()
        {
            ExamERPContext context = new ExamERPContext();
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            ExamERPContext context = new ExamERPContext();
            return context.Products.FirstOrDefault(item=> item.Id == id);
        }

        public Product GetProductByName(string name)
        {
            ExamERPContext context = new ExamERPContext();
            return context.Products.FirstOrDefault(item=> item.Name.Trim().ToLower().Equals(name.Trim().ToLower()));

        }
    }
}
