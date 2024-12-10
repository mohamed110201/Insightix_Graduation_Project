using FluentValidation;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
namespace Graduation_Project.Modules.Systems.Validators
{
    public class AddSystemValidator : AbstractValidator<AddSystemDto>
    {
        private readonly ISystemsRepository _systemsRepository;

        public AddSystemValidator(ISystemsRepository systemsRepository)
        {
            _systemsRepository = systemsRepository;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(25)
                .Must(UniqueSystem)
                .WithMessage("System with this name already exists");  
        }

        private bool UniqueSystem(string name)
        {
            var existingSystem = _systemsRepository.SearchByName(name);
            if (existingSystem == null)
                return true;
            return false;
        }


    }

}

