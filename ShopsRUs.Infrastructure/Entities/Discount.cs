using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Infrastructure.Entities
{
    public class Discount
    {
        public long DiscountId { get; set; }
        public string DiscountType { get; set; }
        //public decimal? DiscountAmount { get; set; }
        public int DiscountPercentage { get; set; }
        //public string PercentageType { get; set; }

    }
}
