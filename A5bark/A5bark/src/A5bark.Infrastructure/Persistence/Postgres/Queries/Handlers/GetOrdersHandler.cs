using A5bark.Application.DTOs;
using A5bark.Application.Queries;
using A5bark.Infrastructure.Mappings;
using A5bark.Infrastructure.Persistence.EF;
using A5bark.Infrastructure.Persistence.EF.Repositories;
using A5bark.Infrastructure.Persistence.Postgres.Models;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A5bark.Infrastructure.Persistence.Postgres.Queries.Handlers
{
    public class GetOrdersHandler : IQueryHandler<GetOrders, IEnumerable<OrderDto>>
    {
        private readonly IEntityFrameworkRepository<OrderModel, Guid, A5barkDbContext> _repository;

        public GetOrdersHandler(IEntityFrameworkRepository<OrderModel, Guid, A5barkDbContext> repository)
            => _repository = repository;

        public async Task<IEnumerable<OrderDto>> HandleAsync(GetOrders query)
            => (await _repository.FindAsync(_ => true, x => x.Items))
                .Select(order => order.AsDto());
    }
}
