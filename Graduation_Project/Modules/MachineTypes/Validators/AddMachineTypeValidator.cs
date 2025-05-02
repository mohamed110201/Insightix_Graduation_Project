using FluentValidation;
using Graduation_Project.Modules.MachineTypes.DTOs;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.MachineTypes.Validators;

public class AddMachineTypeValidator : AbstractValidator<MachineTypeRequestDto>
{
    private readonly IMachineTypesRepository _machineTypesRepository;
    public AddMachineTypeValidator(IMachineTypesRepository machineTypesRepository)
    {
        _machineTypesRepository = machineTypesRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(25)
            .Must(UniqueMachineType)
            .WithMessage("Machine Type with this model already exists");

        RuleFor(x => x.MonitoringAttributes)
            .NotNull()
            .Must(ids => ids.Count > 0)
            .WithMessage("Machine Type must have at least one monitoring attribute");
            
        RuleFor(x => x.ResourceConsumptionAttributes)
            .NotNull()
            .Must(ids => ids.Count > 0)
            .WithMessage("Machine Type must have at least one resource consumption attribute");
    }

    private bool UniqueMachineType(string model)
    {
        var existingModel =  _machineTypesRepository.FindByModel(model);
        if (existingModel == null)
            return true;
        return false;
    }

}