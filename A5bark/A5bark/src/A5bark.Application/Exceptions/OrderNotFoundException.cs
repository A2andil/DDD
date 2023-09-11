using System;

namespace A5bark.Application.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public Guid OrderId { get; }

        public OrderNotFoundException(Guid orderId)
            : base($"Order with ID: {orderId} not found.")
                => OrderId = orderId;
    }
}
