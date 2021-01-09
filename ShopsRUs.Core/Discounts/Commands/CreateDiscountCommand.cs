﻿using MediatR;
using ShopsRUs.Core.Discounts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest<DiscountResponse>
    {
        public string DiscountType { get; }
        public decimal? DiscountAmount { get; }
        public string DiscountPercentage { get; }
        public string PercentageType { get; }

        public CreateDiscountCommand(decimal discountAmount, string discountType, string discountPercentage, string percentageType)
        {
            DiscountAmount = discountAmount;
            DiscountType = discountType;
            DiscountPercentage = discountPercentage;
            PercentageType = percentageType;
        }
    }
}
