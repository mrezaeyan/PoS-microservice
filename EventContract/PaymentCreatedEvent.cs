using System;
using MediatR;

namespace EventContract
{
    public class PaymentCreatedEvent : IEvent
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    
}