using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithName("Bashliq");
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithName("Achiqlama");
            RuleFor(p => p.BrandId)
             .GreaterThan(0)
             .WithName("Marka");
            RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithName("Qiymet");
            RuleFor(p => p.Discount)
            .GreaterThan(0)
            .WithName("Endirim");
            RuleFor(p => p.CategoryIDs)
            .NotEmpty()
            .Must(categories => categories.Any())
            .WithName("Kategoriyalar");
        }
    }
}
