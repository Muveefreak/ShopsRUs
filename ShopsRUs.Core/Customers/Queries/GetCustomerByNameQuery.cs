using MediatR;
using ShopsRUs.Core.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Customers.Queries
{
    public class GetCustomerByNameQuery : IRequest<CustomerResponse>
    {
        public string CustomerName { get; set; }

        public GetCustomerByNameQuery(string customerName)
        {
            CustomerName = customerName;
        }
    }
}
