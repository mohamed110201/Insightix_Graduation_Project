using FluentValidation;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.Machines.Validators
{
    public class AddMachineToSystemValidator :AbstractValidator<AddMachineToSystemDto>
    {
        private readonly IMachinesRepository _machinesRepository;

        public AddMachineToSystemValidator(IMachinesRepository machinesRepository)
        {
            _machinesRepository = machinesRepository;
            RuleFor(x => x.SerialNumber)
                .NotEmpty()
                .MaximumLength(25)
                .Must(UniqueMachine)
                .WithMessage("Machine with this SerialNumber already exists ");

            RuleFor(x => x.MachineTypeId)
                .NotEmpty();
                
        }

        private bool UniqueMachine(string serialNumber)
        {
            var existingMachine = _machinesRepository.SearchBySerialNumber(serialNumber);
            if (existingMachine == null)
                return true;
            return false;
        }
    }
}
