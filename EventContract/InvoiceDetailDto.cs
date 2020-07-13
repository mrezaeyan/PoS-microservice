using System;

namespace EventContract
{
    public class InvoiceDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }        
    }
}