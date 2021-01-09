using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Core.Discounts.Commands;
using ShopsRUs.Core.Discounts.Queries;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var query = new GetAllDiscountsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{discountType}")]
        public async Task<IActionResult> GetDiscountPercentageByType(string discountType)
        {
            var query = new GetDiscountPercentageByTypeQuery(discountType);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDiscountPercentageByType), new { orderId = result.DiscountType }, result);
        }
    }
}
