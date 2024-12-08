using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.SystemDto;

namespace Graduation_Project.Services.Interfaces
{
    public interface IMachinesService
    {
        Task<IEnumerable<AllMachinesAcrossAllSystemsDto>> GetAll();
        Task<MachineDetailsDto?> GetById(int id);
        Task<IEnumerable<MachinesInsideSystemDto>> GetMachinesBySystemId(int systemId);
        Task AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto);
        Task<List<MachineTypeMachineResponseDto>> GetMachinesByMachineTypeId(int machineTypeId);

    }
}
