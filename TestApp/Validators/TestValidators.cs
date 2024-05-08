using FluentValidation;

public class TestValidator: AbstractValidator<TestCreateDTO>{
    public TestValidator(){
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty().WithErrorCode("400").WithMessage("Subject Id is required!");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithErrorCode("400").WithMessage("Subject Id has to be greater than 0!");
        RuleFor(x => x.SubjectId).NotEmpty().WithErrorCode("400").WithMessage("Category Id is required!");
        RuleFor(x => x.SubjectId).GreaterThan(0).WithErrorCode("400").WithMessage("Category Id has to be greater than 0!");
    }
}