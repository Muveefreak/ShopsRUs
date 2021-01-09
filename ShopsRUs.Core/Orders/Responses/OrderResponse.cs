﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Responses
{
    public class OrderResponse
    {
        public long OrderId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public string OrderType { get; set; }
        public long CustomerId { get; set; }
    }
}
