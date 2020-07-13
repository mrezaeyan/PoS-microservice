using System.Collections.Generic;
using EventContract;
using MediatR;
using Product.Domain;

namespace Product.Api.Commands
{
    public class UpdateProductCommand : IEvent, IRequest<bool>
    {
        public int InvoiceId { get; set; }
        public InvoiceCreatedEvent InvoiceData { get; set; }
    }

}