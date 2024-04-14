﻿using FluentValidation;
using MinimalWeb.DTO;

namespace MinimalWeb.Validators;

public class ProductValidator : AbstractValidator<ProductDTO>
{
    public ProductValidator()
    {
        RuleFor(b=>b.Name).NotEmpty().MaximumLength(255);
        RuleFor(b => b.Image).Matches("[^\\s]+(\\.(?i)(jpe?g|png|gif|bmp))$");
        RuleFor(b => b.ProductGroupId).NotEmpty();
        RuleFor(b => b.BrandId).NotEmpty();
    }
}
