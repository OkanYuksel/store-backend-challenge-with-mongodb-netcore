using MongoDB.Driver;
using System.Collections.Generic;

namespace Store.Core
{
    public class ProductServices : IProductServices
    {
        private readonly IMongoCollection<Product> _Products;

        public ProductServices(IDbClient dbClient)
        {
            _Products = dbClient.GetProductCollection();
        }

        public Product AddProduct(Product Product)
        {
            _Products.InsertOne(Product);
            return Product;
        }

        public Product GetProduct(string id) => _Products.Find(Product => Product.Id == id).First();

        public List<Product> GetProducts() => _Products.Find(Product => true).ToList();

    }
}
