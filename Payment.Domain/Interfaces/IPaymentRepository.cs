using System.Threading;
using System.Threading.Tasks;
using MongoContext;

namespace Payment.Domain.Interfaces
{
    public interface IPaymentRepository : IMongoRepository<PaymentEntity>
    {
        Task<bool> CanceledPaymentAsync(int id, CancellationToken cancellationToken);
        Task<bool> ConfirmedPaymentAsync(int id, CancellationToken cancellationToken);
    }
}