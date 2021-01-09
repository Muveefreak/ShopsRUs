using FluentValidation;
using ShopsRUs.Core.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Orders.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer Id is required.");

            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("Item name is required.");

            RuleFor(x => x.OrderType)
                .NotEmpty().WithMessage("Order type is required.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.");
        }
    }
}
