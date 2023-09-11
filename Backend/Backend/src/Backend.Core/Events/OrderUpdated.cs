using Backend.Core.Aggregates;
using Backend.Core.BuildingBlocks;

namespace Backend.Core.Events
{
    public class OrderUpdated : IDomainEvent
    {
        public Order Order { get; }

        public OrderUpdated(Order order)
            => Order = order;
    }
}
