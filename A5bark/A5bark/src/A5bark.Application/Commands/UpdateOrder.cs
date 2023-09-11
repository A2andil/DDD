using A5bark.Application.Commands.WriteModels;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;

namespace A5bark.Application.Commands
{
    public record UpdateOrder(Guid Id, Guid BuyerId, AddressWriteModel ShippingAddress, IEnumerable<OrderItemWriteModel> Items, string Status) : ICommand;
}
