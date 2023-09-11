using A5bark.Core.BuildingBlocks;
using System;

namespace A5bark.Core
{
    public sealed class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value)
            : base(value) { }

        public static implicit operator OrderId(Guid orderId)
            => new OrderId(orderId);
    }
}
