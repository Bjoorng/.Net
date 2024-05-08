using FluentValidation;

public class SubjectValidator : AbstractValidator<SubjectCreateDTO>{
    public SubjectValidator(){
        RuleFor(x => x.Name).NotEmpty().WithErrorCode("400").WithMessage("Name Required!");
    }
}