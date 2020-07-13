using System.Threading;
using System.Threading.Tasks;
using MongoContext;

namespace Invoice.Domain.Interfaces
{
    public interface IInvoiceRepository : IMongoRepository<InvoiceEntity>
    {
        Task<bool> PaidAsync(int id, CancellationToken cancellationToken);
        Task<bool> AssignAsync(InvoiceEntity invoiceEntity, CancellationToken cancellationToken);
        Task<bool> FailedAsync(int id, CancellationToken cancellationToken);
    }
}