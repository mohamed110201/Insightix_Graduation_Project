using FluentValidation;
using Graduation_Project.Modules.Failures.DTOs;

namespace Graduation_Project.Modules.Failures.Validators;

public class FailureAddValidator : AbstractValidator<FailureAddDTO>
{
    public FailureAddValidator()
    {
        
        RuleFor(x => x.StartDateTime)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("StartDateTime cannot be in the future.");

        RuleFor(x => x.EndDateTime)
            .GreaterThan(x => x.StartDateTime)
            .When(x => x.EndDateTime.HasValue)
            .WithMessage("EndDateTime must be after StartDateTime.");
        
    }
}
