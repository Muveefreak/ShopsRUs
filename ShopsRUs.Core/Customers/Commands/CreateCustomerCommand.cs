using MediatR;
using ShopsRUs.Core.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string CustomerName { get; }
        public string CustomerType { get; }

        public CreateCustomerCommand(string customerName, string customerType)
        {
            CustomerName = customerName;
            CustomerType = customerType;
        }
    }
}
