using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using MediatR;
using MessageBroker;
using MongoContext;
using Product.Domain.Interfaces;

namespace Product.Api.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEventRepository<IEvent> _eventSourceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;

        public UpdateProductCommandHandler(IMapper mapper, IMongoEventRepository<IEvent> eventSourceRepository,
            IProductRepository invoiceRepository, IEventBus eventBus)
        {
            _mapper = mapper;
            _eventSourceRepository = eventSourceRepository;
            _productRepository = invoiceRepository;
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // TODO: Use Distributed Transaction Like CAP, Saga, ...
            var data = _mapper.Map<IEnumerable<Domain.ProductEntity>>(request.InvoiceData.InvoiceDetails);
            await _productRepository.UpdateQuantityAsync(data, CancellationToken.None);

            var productUpdatedEvent = _mapper.Map<ProductUpdatedEvent>(request);
            await _eventSourceRepository.InsertEventAsync(productUpdatedEvent, cancellationToken);          
            _eventBus.Publish(productUpdatedEvent);
            return true;
        }
    }
}