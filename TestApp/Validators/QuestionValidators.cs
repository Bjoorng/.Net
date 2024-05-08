using FluentValidation;

public class QuestionValidator: AbstractValidator<QuestionCreateDTO>{
    public QuestionValidator(){
        RuleFor(x => x.Text).NotEmpty().WithErrorCode("400").WithMessage("Question Text Is Required!");
        RuleFor(x => x.Difficulty).NotEmpty().WithErrorCode("400").WithMessage("Difficulty Is Required!");
        RuleFor(x => x.SubjectId).NotEmpty().WithErrorCode("400").WithMessage("SubjectID Is Required!");
        RuleFor(x => x.SubjectId).GreaterThan(0).WithErrorCode("400").WithMessage("SubjectID has to be greater than 0!");
        RuleFor(x => x.CategoryId).NotEmpty().WithErrorCode("400").WithMessage("CatgoryID Is Required!");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithErrorCode("400").WithMessage("CatgoryID has to be greater than 0!");
    }
}