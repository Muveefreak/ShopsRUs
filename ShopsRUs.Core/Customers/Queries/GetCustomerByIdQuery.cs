using MediatR;
using ShopsRUs.Core.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public long CustomerId { get; set; }

        public GetCustomerByIdQuery(long customerId)
        {
            CustomerId = customerId;
        }
    }

    
}
