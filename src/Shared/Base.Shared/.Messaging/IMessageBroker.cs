using System.Threading;
using System.Threading.Tasks;
using Base.Shared.Events;

namespace Base.Shared.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
    }
}