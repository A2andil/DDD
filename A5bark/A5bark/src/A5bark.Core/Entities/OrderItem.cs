using A5bark.Core.BuildingBlocks;
using A5bark.Core.ValueObjects;
using System;

namespace A5bark.Core.Entities
{
    public class OrderItem : IEntity<OrderItemId>
    {
        public OrderItemId Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public Amount UnitPrice { get; private set; }
        public Amount Price { get; private set; }

        private OrderItem() { }

        public OrderItem(string name, int quantity, Amount unitPrice)
        {
            Id = new OrderItemId(Guid.NewGuid());
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = quantity * unitPrice;
        }
    }
}
