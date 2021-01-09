﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Core.Orders.Commands;
using ShopsRUs.Core.Orders.Queries;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAllOrdersByCustomerId(long customerId)
        {
            var query = new GetAllOrdersByCustomerIdQuery(customerId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllOrdersByCustomerId), new { orderId = result.CustomerId }, result);
        }
    }
}