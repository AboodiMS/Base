using System.Threading;
using System.Threading.Tasks;
using Base.Shared.Events;

namespace Base.Shared.Messaging
{
    internal interface IAsyncEventDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}