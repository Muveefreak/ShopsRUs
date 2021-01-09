using MediatR;
using ShopsRUs.Core.Discounts.Commands;
using ShopsRUs.Core.Discounts.Responses;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Discounts.Handlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, DiscountResponse>
    {
        private readonly ShopsRUsDbContext _dbContext;

        public CreateDiscountHandler(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DiscountResponse> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = request.ToCreateEntity();

            _dbContext.Discounts.Add(discount);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var response = discount.ToResponse();

            return response;
        }
    }
}
