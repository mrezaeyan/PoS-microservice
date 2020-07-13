using System;
using System.Collections.Generic;
using MediatR;

namespace EventContract
{
    public class ProductUpdatedEvent : IEvent
    {
        public int InvoiceId { get; set; }
        public InvoiceCreatedEvent InvoiceData { get; set; }
    }
    
}