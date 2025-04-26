using FluentValidation;
using Graduation_Project.DTOs;

namespace Graduation_Project.Validators;

public class AddResourceConsumptionAttributeValidator: AbstractValidator<AddResourceConsumptionAttributeDto>
{
    public AddResourceConsumptionAttributeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Unit).NotEmpty();
    }
}