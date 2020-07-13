using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain;
using Invoice.Domain.Interfaces;
using MongoContext;

namespace Invoice.Infrastructure
{
    public class InvoiceRepository : MongoRepository<Domain.InvoiceEntity>, IInvoiceRepository
    {
        private static IEnumerable<InvoiceEntity> _invoices;
        public InvoiceRepository(MongoDbContext dbContext) : base(dbContext)
        {
            _invoices = new List<InvoiceEntity>
            {
                new InvoiceEntity
                {
                    Id = 1, Status = InvoiceStatus.Outstanding, InvoiceDetails =
                        new List<InvoiceDetailEntity>
                        {
                            new InvoiceDetailEntity {Id = 1, Quantity = 2, ProductId = 1, UnitPrice = 10000},
                            new InvoiceDetailEntity {Id = 2, Quantity = 3, ProductId = 2, UnitPrice = 20000}
                        }
                },
                
                new InvoiceEntity
                {
                    Id = 2, Status = InvoiceStatus.Outstanding, InvoiceDetails =
                        new List<InvoiceDetailEntity>
                        {
                            new InvoiceDetailEntity {Id = 3, Quantity = 5, ProductId = 5, UnitPrice = 10000}
                        }
                },
            };
        }

        public Task<bool> PaidAsync(int id, CancellationToken cancellationToken)
        {
            _invoices.Single(a => a.Id == id).Status = InvoiceStatus.Paid;
            return Task.FromResult(true);
        }

        public Task<bool> AssignAsync(InvoiceEntity invoiceEntity, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task<bool> FailedAsync(int id, CancellationToken cancellationToken)
        {
            _invoices.Single(a => a.Id == id).Status = InvoiceStatus.Failed;
            return Task.FromResult(true);
        }
        
        public new Task<InvoiceEntity> GetAsync(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(_invoices.Single(a => a.Id == id));
        }
    }
}