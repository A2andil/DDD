using Backend.Core.Aggregates;
using Backend.Core.Repositories;
using Backend.Infrastructure.Mappings;
using Backend.Infrastructure.Persistence.EF;
using Backend.Infrastructure.Persistence.EF.Repositories;
using Backend.Infrastructure.Persistence.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Persistence.Postgres.Repositories
{
    public sealed class OrdersRepository : IOrdersRepository
    {
        private readonly IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> _repository;

        public OrdersRepository(IEntityFrameworkRepository<OrderModel, Guid, BackendDbContext> repository)
            => _repository = repository;

        public async Task<Order> GetAsync(Guid id)
            => (await _repository.GetAsync(id, x => x.Items))
                ?.AsEntity();

        public async Task<IEnumerable<Order>> BrowseAsync()
            => (await _repository.FindAsync(_ => true, x => x.Items))
                ?.Select(order => order.AsEntity());

        public async Task AddAsync(Order order)
            => await _repository.AddAsync(order.AsDatabaseModel());

        public async Task UpdateAsync(Order order)
            => await _repository.UpdateAsync(order.AsDatabaseModel());
    }
}
