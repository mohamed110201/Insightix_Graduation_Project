using Graduation_Project.Data.Dtos.MachineDto;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMachineRepository
{
    Task<List<Machine>> GetMachinesByMachineTypeIdAsync(int machineTypeId);
}