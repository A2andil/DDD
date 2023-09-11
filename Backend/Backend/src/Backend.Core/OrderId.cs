using Backend.Core.BuildingBlocks;
using System;

namespace Backend.Core
{
    public sealed class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value)
            : base(value) { }

        public static implicit operator OrderId(Guid orderId)
            => new OrderId(orderId);
    }
}
