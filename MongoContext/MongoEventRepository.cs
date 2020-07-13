using System.Threading;
using System.Threading.Tasks;
using EventContract;

namespace MongoContext
{
    public class MongoEventRepository<TEvent> : IMongoEventRepository<TEvent> where TEvent : IEvent
    {
        private readonly MongoDbEventContext _dbContext;

        public MongoEventRepository(MongoDbEventContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> InsertEventAsync(TEvent domainEntity, CancellationToken cancellationToken)
        {
            return await _dbContext.AddAsync(domainEntity, cancellationToken);
        }
    }
}