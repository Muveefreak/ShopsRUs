using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Responses
{
    public class DiscountResponse
    {
        public long DiscountId { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string DiscountPercentage { get; set; }
        public string PercentageType { get; set; }
    }
}
