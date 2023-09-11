using A5bark.Core.Types;
using A5bark.Infrastructure.Persistence.Types;
using System;
using System.Collections.Generic;

namespace A5bark.Infrastructure.Persistence.Postgres.Models
{
    public class OrderModel : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
        public int Version { get; set; }
    }
}
