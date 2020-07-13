using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Domain
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            CreatedOn = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}