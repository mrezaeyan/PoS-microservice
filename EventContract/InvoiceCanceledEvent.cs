using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;

namespace EventContract
{
    public class InvoiceCanceledEvent : IEvent
    {
        public int InvoiceId { get; set; }
        public InvoiceCreatedEvent InvoiceData { get; set; }

    }
}