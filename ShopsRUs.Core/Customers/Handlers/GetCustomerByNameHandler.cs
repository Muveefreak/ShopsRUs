using MediatR;
using ShopsRUs.Core.Customers.Queries;
using ShopsRUs.Core.Customers.Responses;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Customers.Handlers
{
    public class GetCustomerByNameHandler : IRequestHandler<GetCustomerByNameQuery, CustomerResponse>
    {
        private readonly ShopsRUsDbContext _dbContext;

        public GetCustomerByNameHandler(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
        {
            var customerEntity = await _dbContext.Customers
                .FindAsync(request.CustomerName);

            var response = customerEntity?.ToResponse();
            return response;
        }
    }
}
