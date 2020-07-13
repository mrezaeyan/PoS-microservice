using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using Invoice.Api.Commands;
using MediatR;
using MessageBroker;

namespace Invoice.Api.EventHandlers
{
    public class ProductUpdatedEventHandler : IEventHandler<ProductUpdatedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductUpdatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task Handle(ProductUpdatedEvent @event)
        {
            // TODO: Call Update Invoice and Send Event Invoice Confirmed Event
            return Task.CompletedTask;
        }
    }
}