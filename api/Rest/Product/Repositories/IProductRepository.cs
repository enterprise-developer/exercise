namespace Product.Repositories
{
    using System.Collections.Generic;
    public interface IProductRepository
    {
        IList<Product.Entity.Product> GetAlls();
    }
}
