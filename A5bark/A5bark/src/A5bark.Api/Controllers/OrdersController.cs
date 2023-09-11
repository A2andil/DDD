using A5bark.Application.Commands;
using A5bark.Application.Dispatchers;
using A5bark.Application.DTOs;
using A5bark.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A5bark.Api.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(IDispatcher dispatcher)
            : base(dispatcher) { }

        /// <summary>
        /// Returns a single order by `ID`.
        /// </summary>
        /// <param name="query.Id">The unique order identifier.</param>
        /// <response code="200">Returns a single specific order.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] GetOrder query)
            => Select(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Returns a list of orders.
        /// </summary>
        /// <response code="200">Returns a list containing all orders.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetOrders query)
            => Select(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <response code="201">Returns the newly created order.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateOrder command)
        {
            await Dispatcher.SendAsync(command);

            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        /// <summary>
        /// Updates the details of a specific order.
        /// </summary>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, UpdateOrder command)
        {
            await Dispatcher.SendAsync(new UpdateOrder(id, command.BuyerId, command.ShippingAddress, command.Items, command.Status));

            return NoContent();
        }
    }
}
