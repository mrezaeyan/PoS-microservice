using MediatR;

namespace EventContract
{
    public class InvoiceConfirmedEvent : IEvent
    {
        public int InvoiceId { get; set; }
        public InvoiceCreatedEvent InvoiceData { get; set; }
        
    }
}