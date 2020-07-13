using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.Domain
{
    public class PaymentEntity
    {
        public PaymentEntity()
        {
            Status = PaymentStatus.PendingInvoice;
            CreatedOn = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}