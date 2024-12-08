using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class MachineServices(IMachineRepository machineRepository) : IMachineServices
{
    public async Task<List<MachineTypeMachineResponseDto>> GetMachinesByMachineTypeIdAsync(int machineTypeId)
    {
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

