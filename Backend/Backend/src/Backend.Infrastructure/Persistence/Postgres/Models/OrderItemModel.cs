using Backend.Infrastructure.Persistence.Types;
using System;

namespace Backend.Infrastructure.Persistence.Postgres.Models
{
    public class OrderItemModel : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public OrderModel Order { get; set; }
    }
}
