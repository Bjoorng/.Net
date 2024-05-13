﻿namespace Author.Signup
{
    internal class Request
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("your name is required!")
                .MinimumLength(3).WithMessage("name is too short!")
                .MaximumLength(25).WithMessage("name is too long!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email address is required!")
                .EmailAddress().WithMessage("the format of your email address is wrong!");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("a username is required!")
                .MinimumLength(3).WithMessage("username is too short!")
                .MaximumLength(15).WithMessage("username is too long!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("a password is required!")
                .MinimumLength(10).WithMessage("password is too short!")
                .MaximumLength(25).WithMessage("password is too long!");
        }
    }

    internal class Response
    {
        public string Message { get; set; }
    }
}
