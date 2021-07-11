

using MongoDB.Bson.Serialization.Attributes;

namespace Store.Core
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string UnitType { get; set; }
    }
}