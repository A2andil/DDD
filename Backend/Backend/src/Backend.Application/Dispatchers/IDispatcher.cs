using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using System.Threading.Tasks;

namespace Backend.Application.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
