using A5bark.Core.Aggregates;
using A5bark.Core.BuildingBlocks;

namespace A5bark.Core.Events
{
    public class OrderUpdated : IDomainEvent
    {
        public Order Order { get; }

        public OrderUpdated(Order order)
            => Order = order;
    }
}
