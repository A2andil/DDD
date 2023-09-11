using A5bark.Core.BuildingBlocks;
using A5bark.Core.Entities;

namespace A5bark.Core.Events
{
    public class OrderItemAdded : IDomainEvent
    {
        public OrderItem OrderItem { get; }

        public OrderItemAdded(OrderItem orderItem)
            => OrderItem = orderItem;
    }
}
