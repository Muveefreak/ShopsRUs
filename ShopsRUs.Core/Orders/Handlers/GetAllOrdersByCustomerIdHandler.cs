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
            var orderStatus = ((char)Enums.OrderStatus.Unpaid).ToString(); 
            var orders = _dbContext.Orders.AsQueryable().Where(x => x.CustomerId == request.CustomerId && x.OrderStatus == orderStatus);

            var responses = orders.Select(x => x.ToResponse()).ToList();

            return responses;

        }
    }
}
