using Graduation_Project.Data.Dtos.MachineDto;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMachinetypeRepository
{
    Task<List<MachineType>> GetAllMachineTypesAsync();
    Task<MachineType?> GetMachineTypeByIdAsync(int id);
    Task<MachineType> AddMachineTypeAsync(MachineType machineType);
  
}