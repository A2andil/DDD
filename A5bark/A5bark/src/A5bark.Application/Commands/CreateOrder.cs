using A5bark.Application.Commands.WriteModels;
using A5bark.Core;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace A5bark.Application.Commands
{
    public record CreateOrder([Required] Guid BuyerId, [Required] AddressWriteModel ShippingAddress, [Required] IEnumerable<OrderItemWriteModel> Items) : ICommand
    {
        public Guid Id { get; init; } = new OrderId(Guid.NewGuid());
    }
}
