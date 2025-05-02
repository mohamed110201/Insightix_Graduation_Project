using FluentValidation;
using Graduation_Project.Modules.Failures.DTOs;

namespace Graduation_Project.Modules.Failures.Validators;

public class FailureAddValidator : AbstractValidator<FailureAddDTO>
{
    public FailureAddValidator()
    {
        
        RuleFor(x => x.StartDateTimeOffset)
            .NotEmpty()
            .LessThanOrEqualTo(DateTimeOffset.UtcNow).WithMessage("StartDateTimeOffset cannot be in the future.");

        RuleFor(x => x.EndDateTimeOffset)
            .GreaterThan(x => x.StartDateTimeOffset)
            .When(x => x.EndDateTimeOffset.HasValue)
            .WithMessage("EndDateTimeOffset must be after StartDateTimeOffset.");
        
    }
}
