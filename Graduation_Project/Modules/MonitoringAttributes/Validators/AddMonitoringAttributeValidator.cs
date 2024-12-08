using FluentValidation;
using Graduation_Project.DTOs;

namespace Graduation_Project.Validators;

public class AddMonitoringAttributeValidator: AbstractValidator<AddMonitoringAttributeDto>
{
    public AddMonitoringAttributeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Unit).NotEmpty();
    }
}