﻿using Microsoft.EntityFrameworkCore;
using ShopsRUs.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopsRUs.Infrastructure
{
    public class Seed
    {
        public static async Task SeedCustomers(ShopsRUsDbContext context)
        {
            if (await context.Customers.AnyAsync()) return;

            var customerData = await System.IO.File.ReadAllTextAsync("../ShopsRUs.Infrastructure/CustomerSeedData.json");

            var customers = JsonSerializer.Deserialize<List<Customer>>(customerData);

            foreach (var customer in customers)
            {
                customer.CustomerName = customer.CustomerName.ToLower();

                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }
        
        public static async Task SeedDiscounts(ShopsRUsDbContext context)
        {
            if (await context.Discounts.AnyAsync()) return;

            var discountData = await System.IO.File.ReadAllTextAsync("../ShopsRUs.Infrastructure/DiscountSeedData.json");

            var discounts = JsonSerializer.Deserialize<List<Discount>>(discountData);

            foreach(var discount in discounts)
            {
                discount.DiscountType = discount.DiscountType.ToLower();

                context.Discounts.Add(discount);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedOrders(ShopsRUsDbContext context)
        {
            if (await context.Orders.AnyAsync()) return;


            List<Int64> listIds = new List<Int64>();
            var orderData = await System.IO.File.ReadAllTextAsync("../ShopsRUs.Infrastructure/OrderSeedData.json");

            var orders = JsonSerializer.Deserialize<List<Order>>(orderData);

            var customers = await context.Customers.ToListAsync();

            customers.ForEach(x =>
            {
                listIds.Add(x.Id);
            });

            foreach (var order in orders)
            {
                //Int64[] newList = Array.ConvertAll(list.Split(','), s => Int64.Parse(s));
                Random random = new Random();
                int rnd = random.Next(0, listIds.Count);
                order.CustomerId = listIds[rnd];

                context.Orders.Add(order);
            }

            await context.SaveChangesAsync();
        }
    }
}
