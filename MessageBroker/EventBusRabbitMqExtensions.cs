using System;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker
{
    public static class EventBusRabbitMqExtensions
    {
        public static void AddEventBusRabbitMq(this IServiceCollection services,
            Action<EventBusRabbitMqOptions> configureOptions)
        {
            var options = new EventBusRabbitMqOptions();
            configureOptions(options);
            services.Configure(configureOptions);

            services.AddSingleton<IRabbitMqPersistentConnection, DefaultRabbitMqPersistentConnection>();
            services.AddEventBus<EventBusRabbitMq>();
        }

    }
}