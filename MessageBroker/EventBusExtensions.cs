using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker
{
    public static class EventBusExtensions
    {
        public static void AddEventBus<TEventBus>(this IServiceCollection services) where TEventBus : class, IEventBus
        {
            services.AddSingleton<IEventBus, TEventBus>();
            services.AddSingleton<IEventBusSubscriptionsManager, EventBusSubscriptionsManager>();
        }
    }
}