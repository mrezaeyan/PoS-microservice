using System.Threading;
using System.Threading.Tasks;
using EventContract;

namespace MongoContext
{
    public interface IMongoEventRepository<TEvent> where TEvent : IEvent
    {
        Task<bool> InsertEventAsync(TEvent domainEntity, CancellationToken cancellationToken);
    }
}