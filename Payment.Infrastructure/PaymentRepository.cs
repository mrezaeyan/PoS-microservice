using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoContext;
using Payment.Domain;
using Payment.Domain.Interfaces;

namespace Payment.Infrastructure
{
    public class PaymentRepository : MongoRepository<Domain.PaymentEntity>, IPaymentRepository
    {
        private static IEnumerable<PaymentEntity> _paymentEntities;
        public PaymentRepository(MongoDbContext dbContext) : base(dbContext)
        {
            _paymentEntities = new List<PaymentEntity>();
        }
        public new Task<int> AddAsync(PaymentEntity domainEntity, CancellationToken cancellationToken)
        {
            domainEntity.Id = _paymentEntities.Count() + 1;
            _paymentEntities.ToList().Add(domainEntity);
            return Task.FromResult(domainEntity.Id);
        }
        public Task<bool> CanceledPaymentAsync(int id, CancellationToken cancellationToken)
        {
            _paymentEntities.Single(a => a.Id == id).Status = PaymentStatus.Canceled;
            return Task.FromResult(true);
        }

        public Task<bool> ConfirmedPaymentAsync(int id, CancellationToken cancellationToken)
        {
            _paymentEntities.Single(a => a.Id == id).Status = PaymentStatus.Paid;
            return Task.FromResult(true);
        }
    }
}