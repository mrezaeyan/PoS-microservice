using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace EventContract
{
    public class InvoiceCreatedEvent : IEvent
    {
        public InvoiceCreatedEvent()
        {
            InvoiceDetails = new List<InvoiceDetailDto>();
        }
        
        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
        
        public IEnumerable<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
}