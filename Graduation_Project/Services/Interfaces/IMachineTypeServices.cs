using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.MachineTypeDto;

namespace Graduation_Project.Services.Interfaces;

public interface IMachineTypeServices
{
    Task<List<MachineTypeGetAllDto>> GetAllMachineTypesAsync();
    Task<MachineTypeGetByIdDto?> GetMachineTypeByIdAsync(int id);
    Task<MachineTypeGetByIdDto> AddMachineTypeAsync(MachineTypeRequestDto machineTypeRequestDto);

}