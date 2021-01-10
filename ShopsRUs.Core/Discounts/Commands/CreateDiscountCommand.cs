using MediatR;
using ShopsRUs.Core.Discounts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest<DiscountResponse>
    {
        public string DiscountType { get; }
        public float? DiscountAmount { get; }
        public int DiscountPercentage { get; }
        public string IsPercentageType { get; }

        public CreateDiscountCommand(float discountAmount, string discountType, int discountPercentage, string isPercentageType)
        {
            DiscountAmount = discountAmount;
            DiscountType = discountType;
            DiscountPercentage = discountPercentage;
            IsPercentageType = isPercentageType;
        }
    }
}
