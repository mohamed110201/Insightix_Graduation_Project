using FluentValidation;
using Graduation_Project.Modules.Authentication.DTOs;

namespace Graduation_Project.Modules.Authentication.Validators
{
    public class LoginUserValidator :AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator() {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username Is Required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Is Required");

        }
    }
}
