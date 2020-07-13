using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventContract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Invoice.Domain
{
    public class InvoiceEntity
    {
        public InvoiceEntity()
        {
            InvoiceDetails = new List<InvoiceDetailEntity>();
            Status = InvoiceStatus.Outstanding;
            CreatedOn = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount => InvoiceDetails.Sum(a => a.TotalPrice);
        public InvoiceStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal PaidAmount { get; set; }
        
        public IEnumerable<InvoiceDetailEntity> InvoiceDetails { get; set; }
    }
}