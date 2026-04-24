using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class UserValidator : AbstractValidator<UserRegister>
    {
        public UserValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required.")
                .MinimumLength(6).WithMessage("Minimum 6 characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#@$!%*?&])(?=.*[ա-ֆԱ-Ֆ])")

                .WithMessage("Password must contain: Upper and lower case characters, number, specsymbol and an armenian character.")

                .Must((model, password) => !password.Contains(model.Username, StringComparison.OrdinalIgnoreCase))
                .WithMessage("Password must not contain a username.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past");
        }
    }
}
