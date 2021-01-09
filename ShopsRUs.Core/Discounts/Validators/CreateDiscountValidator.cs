using FluentValidation;
using ShopsRUs.Core.Discounts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Validators
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountCommand>
    {
        
        public CreateDiscountValidator()
        {
            List<string> conditions = new List<string>() { "P", "A" };
            String join = String.Join(",", conditions);

            RuleFor(x => x.DiscountType)
                .NotEmpty().WithMessage("Discount Type is required.");

            RuleFor(x => x.DiscountType)
                .Must(x => conditions.Contains(x))
                .WithMessage($"Please only pass: {join} as Discount types.");

            RuleFor(x => x.PercentageType)
                .NotEmpty().When(x => x.DiscountType == "P").WithMessage("Percentage Type is required.");

            RuleFor(x => x.DiscountPercentage)
                .NotEmpty().When(x => x.DiscountType == "P").WithMessage("Discount Percentage is required.");

            RuleFor(x => x.DiscountAmount)
                .NotEmpty().When(x => x.DiscountType == "A").WithMessage("Discount Amount is required.");

        }
    }
}
