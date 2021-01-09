using MediatR;
using ShopsRUs.Core.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public string ItemName { get; }
        public decimal Amount { get; }
        public string OrderType { get; }
        public long CustomerId { get; }

        public CreateOrderCommand(decimal amount, string itemName, string orderType, long customerId)
        {
            Amount = amount;
            ItemName = itemName;
            OrderType = orderType;
            CustomerId = customerId;
        }
    }
}
