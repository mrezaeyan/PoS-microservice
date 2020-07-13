using System;
using System.Runtime;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoContext
{
    internal class EventSource
    {
        public EventSource()
        {
            CreatedOn = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string EventData { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EventName { get; set; }

        public EventStatus Status { get; set; }
    }

    internal enum EventStatus
    {
        Published,
        Received
    }
}