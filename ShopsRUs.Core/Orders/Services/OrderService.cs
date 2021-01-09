using MediatR;
using ShopsRUs.Core.Orders.Interfaces;
using ShopsRUs.Core.Orders.Queries;
using ShopsRUs.Core.Orders.Responses;
using ShopsRUs.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Decimal> GetTotalInvoice(string customerId, CancellationToken cancellationToken)
        {
            var query = new GetAllOrdersByCustomerIdQuery(customerId);
            var result = await _mediator.Send(query);

            var orderManager = new OrderManager(result);
            var totalInvoiceWithoutDiscount = orderManager.Total();

            // Call Discount class

            return orderManager.Total();
        }
    }

    public class OrderManager
    {
        public OrderManager(List<OrderResponse> orders)
        {
            Orders = orders;
        }

        public List<OrderResponse> Orders { get; set; }

        public decimal Total() => Orders.Sum(x => x.Amount);
    }


}
