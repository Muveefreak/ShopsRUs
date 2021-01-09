using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Orders.Queries;
using ShopsRUs.Core.Orders.Responses;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Orders.Handlers
{
    public class GetAllOrdersByCustomerIdHandler : IRequestHandler<GetAllOrdersByCustomerIdQuery, List<OrderResponse>>
    {
        private readonly ShopsRUsDbContext _dbContext;

        public GetAllOrdersByCustomerIdHandler(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var orderStatus = Enums.OrderStatus.Unpaid.ToString();
            var orders = await _dbContext.Orders.ToListAsync(cancellationToken: cancellationToken);

            var responses = orders.Where(x => x.OrderStatus == orderStatus).Select(x => x.ToResponse()).ToList();

            return responses;

        }
    }
}
