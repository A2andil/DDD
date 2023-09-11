using Backend.Application.DTOs;
using Backend.Application.Queries;
using Backend.Infrastructure.Mappings;
using Backend.Infrastructure.Persistence.EF;
using Backend.Infrastructure.Persistence.EF.Repositories;
using Backend.Infrastructure.Persistence.Postgres.Models;
using Convey.CQRS.Queries;
using System;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Persistence.Postgres.Queries.Handlers
{
    public class GetOrderHandler : IQueryHandler<GetOrder, OrderDto>
    {
        private readonly IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> _repository;

        public GetOrderHandler(IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> repository)
            => _repository = repository;

        public async Task<OrderDto> HandleAsync(GetOrder query)
            => (await _repository.GetAsync(x => x.Id == query.Id))
                ?.AsDto();
    }
}
