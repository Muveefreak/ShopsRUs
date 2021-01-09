﻿using FluentValidation;
using ShopsRUs.Core.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Customers.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer Name is required.");

            RuleFor(x => x.CustomerType)
                .NotEmpty().WithMessage("Customer Type is required.");
        }
    }
}
