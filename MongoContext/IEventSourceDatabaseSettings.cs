namespace MongoContext
{
    public interface IEventSourceDatabaseSettings
    {
        string EventsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}