using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using Invoice.Domain.Interfaces;
using MediatR;
using MessageBroker;
using MongoContext;

namespace Invoice.Api.Commands
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEventRepository<IEvent> _eventSourceRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IEventBus _eventBus;

        public CreateInvoiceCommandHandler(IMapper mapper, IMongoEventRepository<IEvent> _eventSourceRepository,
            IInvoiceRepository invoiceRepository, IEventBus eventBus)
        {
            _mapper = mapper;
            this._eventSourceRepository = _eventSourceRepository;
            _invoiceRepository = invoiceRepository;
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            // TODO: Use Distributed Transaction Like CAP, Saga, ...
            var data = await _invoiceRepository.GetAsync(request.InvoiceId, cancellationToken);
            data.PaidAmount = request.Amount;
            data.PaymentId = request.PaymentId;

            await _invoiceRepository.AssignAsync(data, CancellationToken.None);
            
            var invoiceCreatedEvent = _mapper.Map<InvoiceCreatedEvent>(request);
            invoiceCreatedEvent.InvoiceDetails = _mapper.Map<IEnumerable<InvoiceDetailDto>>(data.InvoiceDetails);
            await _eventSourceRepository.InsertEventAsync(invoiceCreatedEvent, cancellationToken);          
            
            _eventBus.Publish(invoiceCreatedEvent);
            return true;
        }
    }
}