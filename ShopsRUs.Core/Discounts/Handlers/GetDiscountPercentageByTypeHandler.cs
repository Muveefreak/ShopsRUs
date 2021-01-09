using MediatR;
using ShopsRUs.Core.Discounts.Queries;
using ShopsRUs.Core.Discounts.Responses;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Discounts.Handlers
{
    public class GetDiscountPercentageByTypeHandler : IRequestHandler<GetDiscountPercentageByTypeQuery, DiscountResponse>
    {
        private readonly ShopsRUsDbContext _dbContext;

        public GetDiscountPercentageByTypeHandler(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DiscountResponse> Handle(GetDiscountPercentageByTypeQuery request, CancellationToken cancellationToken)
        {

            var discountEntity = await _dbContext.Discounts
               .FindAsync(request.DiscountType);

            var response = discountEntity?.ToResponse();
            return response;

        }
    }

    
}
