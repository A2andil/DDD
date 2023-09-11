using A5bark.Application.DTOs;
using A5bark.Application.Queries;
using A5bark.Infrastructure.Mappings;
using A5bark.Infrastructure.Persistence.EF;
using A5bark.Infrastructure.Persistence.EF.Repositories;
using A5bark.Infrastructure.Persistence.Postgres.Models;
using Convey.CQRS.Queries;
using System;
using System.Threading.Tasks;

namespace A5bark.Infrastructure.Persistence.Postgres.Queries.Handlers
{
    public class GetOrderHandler : IQueryHandler<GetOrder, OrderDto>
    {
        private readonly IEntityFrameworkRepository<OrderModel, Guid, A5barkDbContext> _repository;

        public GetOrderHandler(IEntityFrameworkRepository<OrderModel, Guid, A5barkDbContext> repository)
            => _repository = repository;

        public async Task<OrderDto> HandleAsync(GetOrder query)
            => (await _repository.GetAsync(x => x.Id == query.Id))
                ?.AsDto();
    }
}
