using MediatR;
using ShopsRUs.Core.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Queries
{

    public class GetAllOrdersByCustomerIdQuery : IRequest<List<OrderResponse>>
    {
        public string CustomerId { get; set; }

        public GetAllOrdersByCustomerIdQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
