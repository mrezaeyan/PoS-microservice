using System.Threading.Tasks;
using EventContract;

namespace MessageBroker
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}