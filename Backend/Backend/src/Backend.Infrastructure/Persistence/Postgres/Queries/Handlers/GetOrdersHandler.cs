using Backend.Application.DTOs;
using Backend.Application.Queries;
using Backend.Infrastructure.Mappings;
using Backend.Infrastructure.Persistence.EF;
using Backend.Infrastructure.Persistence.EF.Repositories;
using Backend.Infrastructure.Persistence.Postgres.Models;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Persistence.Postgres.Queries.Handlers
{
    public class GetOrdersHandler : IQueryHandler<GetOrders, IEnumerable<OrderDto>>
    {
        private readonly IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> _repository;

        public GetOrdersHandler(IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> repository)
            => _repository = repository;

        public async Task<IEnumerable<OrderDto>> HandleAsync(GetOrders query)
            => (await _repository.FindAsync(_ => true, x => x.Items))
                .Select(order => order.AsDto());
    }
}
