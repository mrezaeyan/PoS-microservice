namespace MessageBroker
{
    public class EventBusRabbitMqOptions
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string QueueName { get; set; } = "POS_Events";

        public string BrokerName { get; set; } = "EventBus";

        public int RetryCount { get; set; } = 5;
    }
}