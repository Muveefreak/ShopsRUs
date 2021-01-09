using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Customers.Responses
{
    public class CustomerResponse
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
    }
}
