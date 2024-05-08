using FluentValidation;

public class CategoryValidator: AbstractValidator<CategoryCreateDTO>{
    public CategoryValidator(){
        RuleFor(x => x.Name).NotEmpty().WithErrorCode("400").WithMessage("Category Name Required");
        RuleFor(x => x.SubjectId).NotEmpty().WithErrorCode("400").WithErrorCode("Subject Id Required");
        RuleFor(x => x.SubjectId).GreaterThan(0).WithErrorCode("400").WithMessage("Subject Id has to be greater than 0!");
    }
}