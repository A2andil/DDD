using A5bark.Application.DTOs;
using Convey.CQRS.Queries;
using System.Collections.Generic;

namespace A5bark.Application.Queries
{
    public class GetOrders : IQuery<IEnumerable<OrderDto>> { }
}
