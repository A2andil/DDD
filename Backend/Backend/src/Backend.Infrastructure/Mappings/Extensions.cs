using Backend.Application.DTOs;
using Backend.Core.Aggregates;
using Backend.Core.Entities;
using Backend.Core.ValueObjects;
using Backend.Infrastructure.Persistence.Postgres.Models;
using System.Linq;

namespace Backend.Infrastructure.Mappings
{
    public static class Extensions
    {
        public static OrderModel AsDatabaseModel(this Order order)
            => new OrderModel
            {
                Id = order.Id,
                BuyerId = order.BuyerId,
                ShippingAddress = new AddressModel
                {
                    City = order.ShippingAddress.City,
                    Street = order.ShippingAddress.Street,
                    Province = order.ShippingAddress.Province,
                    Country = order.ShippingAddress.Country,
                    ZipCode = order.ShippingAddress.ZipCode
                },
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt,
                Version = order.Version,
                Items = order.Items.Select(item => new OrderItemModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Price = item.Price
                })
            };

        public static Order AsEntity(this OrderModel model)
            => new Order(
                model.Id,
                model.BuyerId,
                new Address(
                    model.ShippingAddress.City,
                    model.ShippingAddress.Street,
                    model.ShippingAddress.Province,
                    model.ShippingAddress.Country,
                    model.ShippingAddress.ZipCode),
                model.Items.Select(item => new OrderItem(item.Name, item.Quantity, item.UnitPrice)),
                model.Status,
                model.Version);

        public static OrderDto AsDto(this OrderModel model)
            => new OrderDto
            {
                Id = model.Id,
                BuyerId = model.BuyerId,
                ShippingAddress = new AddressDto
                {
                    City = model.ShippingAddress.City,
                    Street = model.ShippingAddress.Street,
                    Province = model.ShippingAddress.Province,
                    Country = model.ShippingAddress.Country,
                    ZipCode = model.ShippingAddress.ZipCode
                },
                Status = model.Status.ToString().ToLowerInvariant(),
                TotalPrice = model.TotalPrice,
                CreatedAt = model.CreatedAt,
                Items = model.Items.Select(item => new OrderItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Price = item.Price
                })
            };
    }
}
