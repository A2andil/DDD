using Backend.Application.DTOs;
using Convey.CQRS.Queries;
using System.Collections.Generic;

namespace Backend.Application.Queries
{
    public class GetOrders : IQuery<IEnumerable<OrderDto>> { }
}
