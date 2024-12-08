using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class MachineServices(IMachineRepository machineRepository,IMachinetypeRepository machinetypeRepository) : IMachineServices
{
    public async Task<List<MachineTypeMachineResponseDto>> GetMachinesByMachineTypeIdAsync(int machineTypeId)
    {
        var machineType = await machinetypeRepository.GetMachineTypeByIdAsync(machineTypeId);
        if (machineType == null)
        {
            throw new NullReferenceException();
        }
        var machines = await machineRepository.GetMachinesByMachineTypeIdAsync(machineTypeId);

        if (!machines.Any())
        {
        }

        var machinesDto = machines.Select(m => new MachineTypeMachineResponseDto()
        {
            Id = m.Id,
            SystemId = m.SystemId,
            SerialNumber = m.SerialNumber
        });
        return machinesDto.ToList();    
    }
}

