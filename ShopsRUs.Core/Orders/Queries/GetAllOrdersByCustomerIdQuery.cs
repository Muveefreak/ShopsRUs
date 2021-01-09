﻿using MediatR;
using ShopsRUs.Core.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Queries
{

    public class GetAllOrdersByCustomerIdQuery : IRequest<List<OrderResponse>>
    {
        public long CustomerId { get; set; }

        public GetAllOrdersByCustomerIdQuery(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
