using Backend.Core.BuildingBlocks;
using System;

namespace Backend.Core
{
    public class BuyerId : TypedIdValueBase
    {
        public BuyerId(Guid value)
            : base(value) { }

        public static implicit operator BuyerId(Guid buyerId)
            => new BuyerId(buyerId);
    }
}
