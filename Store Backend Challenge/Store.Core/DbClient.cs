using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Store.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Product> _Products;

        public DbClient(IOptions<StoreDatabaseSettings> ProductstoreDbConfig)
        {
            var client = new MongoClient(ProductstoreDbConfig.Value.ConnectionString);
            var database = client.GetDatabase(ProductstoreDbConfig.Value.DatabaseName);
            _Products = database.GetCollection<Product>(ProductstoreDbConfig.Value.StoreCollectionName);
        }

        public IMongoCollection<Product> GetProductCollection() => _Products;
    }
}
