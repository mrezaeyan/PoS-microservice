using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IDynamicEventHandler
    {
        Task Handle(dynamic eventData);
    }
}