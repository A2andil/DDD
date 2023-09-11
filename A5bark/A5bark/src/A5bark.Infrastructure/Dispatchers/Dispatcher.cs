using A5bark.Application.Dispatchers;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using System.Threading.Tasks;

namespace A5bark.Infrastructure.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            => (_commandDispatcher, _queryDispatcher) = (commandDispatcher, queryDispatcher);

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync<TResult>(query);

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
            => await _commandDispatcher.SendAsync(command);
    }
}
