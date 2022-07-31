using System.Threading;
using System.Threading.Tasks;

namespace Base.Shared.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}