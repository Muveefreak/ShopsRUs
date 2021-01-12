using MediatR;
using ShopsRUs.Core.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Commands
{
    public class CreateOrderCommand : IRequest<(OrderResponse response, string message, bool isSuccess)>
    {
        public string ItemName { get; }
        public float Amount { get; }
        public string OrderType { get; }
        public long CustomerId { get; }

        public CreateOrderCommand(float amount, string itemName, string orderType, long customerId)
        {
            Amount = amount;
            ItemName = itemName;
            OrderType = orderType;
            CustomerId = customerId;
        }
    }
}
