using System.Collections.Generic;

namespace Store.Core
{
    public interface IProductServices
    {
        List<Product> GetProducts();
        Product GetProduct(string id);
        Product AddProduct(Product Product);
    }
}
