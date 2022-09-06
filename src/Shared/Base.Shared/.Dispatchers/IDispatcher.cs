using System.Threading;
using System.Threading.Tasks;
using Base.Shared.Commands;
using Base.Shared.Events;
using Base.Shared.Queries;

namespace Base.Shared.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}