using MediatR;

namespace Invoice.Api.Commands
{
    public class CreateInvoiceCommand : IRequest<bool>
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}