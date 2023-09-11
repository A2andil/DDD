using Backend.Application.Commands.WriteModels;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;

namespace Backend.Application.Commands
{
    public record UpdateOrder(Guid Id, Guid BuyerId, AddressWriteModel ShippingAddress, IEnumerable<OrderItemWriteModel> Items, string Status) : ICommand;
}
