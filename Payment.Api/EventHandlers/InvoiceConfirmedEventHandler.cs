using System;
using System.Threading;
using System.Threading.Tasks;
using EventContract;
using MediatR;
using MessageBroker;
using Newtonsoft.Json;
using Payment.Domain.Interfaces;

namespace Payment.Api.EventHandlers
{
    public class InvoiceConfirmedEventHandler : IEventHandler<InvoiceConfirmedEvent>
    {
        private readonly IPaymentRepository _paymentRepository;

        public InvoiceConfirmedEventHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
       
        public async Task Handle(InvoiceConfirmedEvent @event)
        {
            await _paymentRepository.ConfirmedPaymentAsync(@event.InvoiceData.PaymentId, CancellationToken.None);
        }
    }
    
    
}