using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventContract;
using MediatR;
using MessageBroker;
using MongoContext;
using Payment.Domain.Interfaces;

namespace Payment.Api.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMongoEventRepository<IEvent> _eventSourceRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IEventBus _eventBus;

        public CreatePaymentCommandHandler(IMapper mapper, IMongoEventRepository<IEvent> eventSourceRepository, IPaymentRepository paymentRepository, IEventBus eventBus)
        {
            _mapper = mapper;
            _eventSourceRepository = eventSourceRepository;
            _paymentRepository = paymentRepository;
            _eventBus = eventBus;
        }
        public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            // TODO: Use Distributed Transaction Like CAP, Saga, ...

            var paymentCreatedEvent = _mapper.Map<PaymentCreatedEvent>(request);
            var data = _mapper.Map<Domain.PaymentEntity>(paymentCreatedEvent);

            data.Id = await _paymentRepository.AddAsync(data, CancellationToken.None);
            paymentCreatedEvent.PaymentId = data.Id;
            
            await _eventSourceRepository.InsertEventAsync(paymentCreatedEvent, cancellationToken);          
            _eventBus.Publish(paymentCreatedEvent);

            return true;
        }
    }
}