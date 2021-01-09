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
        [Route("GetAllDiscounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var query = new GetAllDiscountsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDiscountPercentageByType")]
        public async Task<IActionResult> GetDiscountPercentageByType([FromQuery] string discountType)
        {
            var query = new GetDiscountPercentageByTypeQuery(discountType);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("CreateDiscount")]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDiscountPercentageByType), new { orderId = result.DiscountType }, result);
        }
    }
}
