using A5bark.Application.DTOs;
using Convey.CQRS.Queries;
using System;

namespace A5bark.Application.Queries
{
    public class GetOrder : IQuery<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
