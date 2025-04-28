using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Product cannot bt empty")
                .MinimumLength(10).WithMessage("Product must be at least 3 characters long.")
                .MaximumLength(200).WithMessage("Product cannot be longer than 200 characters.");
        }
    }
}
