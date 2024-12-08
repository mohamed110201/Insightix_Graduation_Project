using FluentValidation;
using Graduation_Project.Data.Dtos.MachineTypeDto;

namespace Graduation_Project.Validators;

public class MachineTypeValidator : AbstractValidator<MachineTypeRequestDto>
{
    public MachineTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.MonitoringAttributeIds)
            .NotNull()
            .Must(ids => ids.Count > 0);

        RuleFor(x => x.ResourceConsumptionAttributeIds)
            .NotNull()
            .Must(ids => ids.Count > 0);
    }

}