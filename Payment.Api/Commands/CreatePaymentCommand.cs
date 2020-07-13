using MediatR;

namespace Payment.Api.Commands
{
    public class CreatePaymentCommand : IRequest<bool>
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}