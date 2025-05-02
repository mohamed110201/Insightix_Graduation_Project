using FluentValidation;
using Graduation_Project.Modules.Authentication.DTOs;

namespace Graduation_Project.Modules.Authentication.Validators
{
    public class LoginUserValidator :AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator() {
            
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Is Required")
                   .DependentRules(() =>
                   {
                        RuleFor(x => x.Email).EmailAddress().WithMessage("Email must be a valid email");
                    });


            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Is Required");

        }
    }
}
