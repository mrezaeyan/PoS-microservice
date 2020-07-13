namespace MongoContext
{
    public class EventSourceDatabaseSettings : IEventSourceDatabaseSettings
    {
        public string EventsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}