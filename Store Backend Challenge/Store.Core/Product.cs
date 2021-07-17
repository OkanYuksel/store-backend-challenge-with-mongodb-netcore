

using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Store.Core
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("unitPrice")]
        public int UnitPrice { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("unitType")]
        public string UnitType { get; set; }
    }
}