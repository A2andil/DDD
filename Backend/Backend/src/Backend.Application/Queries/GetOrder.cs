using Backend.Application.DTOs;
using Convey.CQRS.Queries;
using System;

namespace Backend.Application.Queries
{
    public class GetOrder : IQuery<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
