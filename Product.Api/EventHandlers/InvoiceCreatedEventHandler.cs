using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using MediatR;
using MessageBroker;
using Product.Api.Commands;

namespace Product.Api.EventHandlers
{
    public class InvoiceCreatedEventHandler : IEventHandler<InvoiceCreatedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InvoiceCreatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(InvoiceCreatedEvent @event)
        {
            var command = new UpdateProductCommand
            {
                InvoiceId = @event.InvoiceId,
                InvoiceData = @event
            };
             await _mediator.Send(command, CancellationToken.None);
        }
    }
}