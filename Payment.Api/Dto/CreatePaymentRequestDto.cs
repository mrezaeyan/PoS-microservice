namespace Payment.Api.Controllers
{
    public class CreatePaymentRequestDto
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}