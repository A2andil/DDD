using A5bark.Core.BuildingBlocks;
using System;

namespace A5bark.Core
{
    public sealed class OrderItemId : TypedIdValueBase
    {
        public OrderItemId(Guid value)
            : base(value) { }

        public static implicit operator OrderItemId(Guid orderItemId)
            => new OrderItemId(orderItemId);
    }
}
