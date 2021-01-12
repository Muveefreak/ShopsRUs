using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Discounts.Commands;
using ShopsRUs.Infrastructure;
using ShopsRUs.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Discounts.Validators
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountCommand>
    {
        private readonly ShopsRUsDbContext _dbContext;

        public CreateDiscountValidator(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CreateDiscountValidator()
        {
            //List<string> conditions = new List<string>() { "affiliate", "employee", "loyalty" };
            //String join = String.Join(",", conditions);

            List<string> percentageTypeConditions = new List<string>() { "Y", "N" };
            String percentageJoin = String.Join(",", percentageTypeConditions);

            RuleFor(x => x.DiscountType)
                .NotEmpty().WithMessage("Discount Type is required.");

            //RuleFor(x => x.DiscountType)
            //    .Must(x => conditions.Contains(x))
            //    .WithMessage($"Please only pass: {join} as Discount types.");

            RuleFor(x => x.IsPercentageType)
                .Must(x => percentageJoin.Contains(x))
                .WithMessage($"Please only pass: {percentageJoin} as Is Percentage Type.");

            RuleFor(x => x.IsPercentageType)
                .NotEmpty().When(x => x.IsPercentageType == "Y").WithMessage("Percentage Type is required.");

            RuleFor(x => x.DiscountPercentage)
                .NotEmpty().When(x => x.IsPercentageType == "Y").WithMessage("Discount Percentage is required.");

            RuleFor(x => x.DiscountAmount)
                .NotEmpty().When(x => x.IsPercentageType == "N").WithMessage("Discount Amount is required.");

        }
    }
}
