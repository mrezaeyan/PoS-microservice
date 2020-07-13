using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using Invoice.Api.Commands;
using MediatR;
using MessageBroker;

namespace Invoice.Api.EventHandlers
{
    public class PaymentCreatedEventHandler : IEventHandler<PaymentCreatedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentCreatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(PaymentCreatedEvent @event)
        {
            var command = _mapper.Map<CreateInvoiceCommand>(@event);
            await _mediator.Send(command, CancellationToken.None);
        }
    }
}