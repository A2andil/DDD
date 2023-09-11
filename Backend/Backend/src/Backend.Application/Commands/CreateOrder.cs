using Backend.Application.Commands.WriteModels;
using Backend.Core;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Commands
{
    public record CreateOrder([Required] Guid BuyerId, [Required] AddressWriteModel ShippingAddress, [Required] IEnumerable<OrderItemWriteModel> Items) : ICommand
    {
        public Guid Id { get; init; } = new OrderId(Guid.NewGuid());
    }
}
