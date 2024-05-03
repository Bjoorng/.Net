using FluentValidation;

public class ProductValidator: AbstractValidator<ProductCreateDTO>{

    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithErrorCode("400").WithMessage("Name is required");
        RuleFor(x => x.Price).NotEmpty().WithErrorCode("400").WithMessage("Price is required");
        RuleFor(x => x.Price).GreaterThan(0).WithErrorCode("400").WithMessage("Price must be greater than 0");
        RuleFor(x => x.Quantity).NotEmpty().WithErrorCode("400").WithMessage("Quantity is required");
        RuleFor(x => x.Quantity).GreaterThan(0).WithErrorCode("400").WithMessage("Quantity must be greater than 0");
        RuleFor(x => x.CategoryId).NotEmpty().WithErrorCode("400").WithMessage("CategoryId is required");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithErrorCode("400").WithMessage("CategoryId is required");
    }
}