using System.Threading;
using System.Threading.Tasks;
using EventContract;
using MediatR;
using MessageBroker;
using Payment.Domain.Interfaces;

namespace Payment.Api.EventHandlers
{
    public class InvoiceCanceledEventHandler : IEventHandler<InvoiceCanceledEvent>
    {
        private readonly IPaymentRepository _paymentRepository;

        public InvoiceCanceledEventHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        public async Task Handle(InvoiceCanceledEvent @event)
        {
            await _paymentRepository.CanceledPaymentAsync(@event.InvoiceData.PaymentId, CancellationToken.None);
        }
    }
}