using Graduation_Project.Data.Dtos.MachineDto;

namespace Graduation_Project.Services.Interfaces;

public interface IMachineServices
{
    Task<List<MachineTypeMachineResponseDto>> GetMachinesByMachineTypeIdAsync(int machineTypeId);

}