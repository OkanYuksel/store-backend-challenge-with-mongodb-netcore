using MongoDB.Driver;

namespace Store.Core
{
    public interface IDbClient
    {
        IMongoCollection<Product> GetProductCollection();
    }
}
