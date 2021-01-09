using ShopsRUs.Core.Discounts.Commands;
using ShopsRUs.Core.Discounts.Responses;
using ShopsRUs.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts
{
    public static class DiscountMapper
    {
        public static Discount ToCreateEntity(this CreateDiscountCommand command)
        {
            var result = new Discount
            {
                DiscountType = command.DiscountType,
                DiscountPercentage = command.DiscountPercentage,
            };

            return result;
        }

        public static DiscountResponse ToResponse(this Discount discount)
        {
            var result = new DiscountResponse
            {
                DiscountId = discount.DiscountId,
                DiscountPercent = discount.DiscountPercentage,
                DiscountType = discount.DiscountType,
            };

            return result;
        }
    }
}
