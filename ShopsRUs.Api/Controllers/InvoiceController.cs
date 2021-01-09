using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Core.Orders.Interfaces;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IOrderService _invoiceService;

        public InvoiceController(IOrderService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetTotalInvoiceAmountByCustomerId(string customerId)
        {
            var result = _invoiceService.GetTotalInvoice(customerId, new CancellationTokenSource().Token);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
