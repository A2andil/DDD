using A5bark.Core.BuildingBlocks;
using System;

namespace A5bark.Core
{
    public class BuyerId : TypedIdValueBase
    {
        public BuyerId(Guid value)
            : base(value) { }

        public static implicit operator BuyerId(Guid buyerId)
            => new BuyerId(buyerId);
    }
}
