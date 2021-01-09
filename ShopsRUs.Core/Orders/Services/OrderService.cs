﻿using MediatR;
using ShopsRUs.Core.Customers.Queries;
using ShopsRUs.Core.Customers.Responses;
using ShopsRUs.Core.Discounts.Queries;
using ShopsRUs.Core.Discounts.Responses;
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
        public async Task<Decimal> GetTotalInvoice(long customerId, CancellationToken cancellationToken)
        {
            var customerDetailsQuery = new GetCustomerByIdQuery(customerId);
            var customerDetails = await _mediator.Send(customerDetailsQuery);

            var customerOrdersQuery = new GetAllOrdersByCustomerIdQuery(customerId);
            var customerOrders = await _mediator.Send(customerOrdersQuery);

            var discountsQuery = new GetAllDiscountsQuery();
            var discounts = await _mediator.Send(discountsQuery);


            var discountManager = new DiscountManager(customerDetails, customerOrders, discounts);
            var totalInvoiceWithDiscount = discountManager.GetDiscountedTotal();

            return totalInvoiceWithDiscount;
        }
    }

    public class OrderManager
    {
        public OrderManager(CustomerResponse customer, List<OrderResponse> orders)
        {
            Customer = customer;
            Orders = orders;
        }

        public List<OrderResponse> Orders { get; set; }
        public CustomerResponse Customer { get; set; }

        public decimal Total() => Orders.Sum(x => x.Amount);
    }

    public class DiscountManager
    {
        public DiscountManager(CustomerResponse customer, List<OrderResponse> orders, List<DiscountResponse> discounts)
        {
            Customer = customer;
            Orders = orders;
            Discounts = discounts;
        }

        public List<OrderResponse> Orders { get; set; }
        public CustomerResponse Customer { get; set; }
        public List<DiscountResponse> Discounts { get; set; }



        public decimal GetDiscountedTotal()
        {
            var totalSum = Orders.Sum(x => x.Amount);
            Decimal totalDiscountedAmount = 0M;
            Decimal totalDiscountForPercentage = 0M;
            Decimal totalDiscountForNonPercentage = 0M;
            foreach (var discount in Discounts)
            {
                if (discount.PercentageDiscount == "Y")
                {
                    if (Customer.CustomerType == discount.DiscountType)
                    {
                        foreach (var order in Orders)
                        {
                            if (order.OrderType != "Grocery")
                            {
                                order.DiscountedAmount = order.Amount * (discount.DiscountPercent / 100);
                                totalDiscountForPercentage += order.DiscountedAmount;
                            }
                        }
                    }
                    else if (Customer.GetAge() > 2)
                    {
                        foreach (var order in Orders)
                        {
                            if (order.OrderType != "Grocery")
                            {
                                order.DiscountedAmount = order.Amount * (discount.DiscountPercent / 100);
                                totalDiscountForPercentage += order.DiscountedAmount;
                            }
                        }
                    }
                }
                if (discount.PercentageDiscount == "N")
                {
                    Decimal valInHundreds = Math.Floor(Convert.ToDecimal(discount.DiscountPercent / 100));
                    decimal constantDiscount = 5M;
                    totalDiscountForNonPercentage = constantDiscount * valInHundreds;
                }

            }

            totalDiscountedAmount = totalSum - (totalDiscountForNonPercentage + totalDiscountForPercentage);
            return totalDiscountedAmount;
        }
    }


}
