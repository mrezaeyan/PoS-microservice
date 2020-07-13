using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EventContract;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoContext
{
    public class MongoDbEventContext
    {
        private readonly IMongoCollection<EventSource> _events;
        public MongoDbEventContext(IEventSourceDatabaseSettings eventSourceDatabaseSettings)
        {
            var client = new MongoClient(eventSourceDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(eventSourceDatabaseSettings.DatabaseName);

            _events = database.GetCollection<EventSource>(eventSourceDatabaseSettings.EventsCollectionName);
        }

        public async Task<bool> AddAsync(IEvent @event, CancellationToken cancellationToken)
        {
           await _events.InsertOneAsync(new EventSource
            {
                Id = new ObjectId(),
                EventData = JsonConvert.SerializeObject(@event),
                EventName = @event.GetType().Name,
                Status = EventStatus.Published
            }, cancellationToken: cancellationToken);
           
           return true;
        }
    }
}