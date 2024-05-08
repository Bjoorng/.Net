using FluentValidation;

public class AnswerValidator: AbstractValidator<AnswerDTO>{
    public AnswerValidator(){
        RuleFor(x => x.Text).NotEmpty().WithErrorCode("400").WithMessage("Text required!");
    }
}