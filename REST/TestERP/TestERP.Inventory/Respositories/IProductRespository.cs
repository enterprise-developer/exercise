using System.Collections.Generic;
using TestERP.Inventory.Entity;

namespace TestERP.Inventory.Respositories
{
   public interface IProductRespository
    {
        IList<Product> GetAll();
    }
}
