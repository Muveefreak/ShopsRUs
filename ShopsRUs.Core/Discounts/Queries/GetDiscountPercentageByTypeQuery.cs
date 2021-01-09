using MediatR;
using ShopsRUs.Core.Discounts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Queries
{
    public class GetDiscountPercentageByTypeQuery : IRequest<DiscountResponse>
    {
        public string DiscountType { get; set; }

        public GetDiscountPercentageByTypeQuery(string discountType)
        {
            DiscountType = discountType;
        }
    }
}
