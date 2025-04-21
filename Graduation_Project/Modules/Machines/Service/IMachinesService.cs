using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Modules.Machines.DTOs;

namespace Graduation_Project.Services.Interfaces
{
    public interface IMachinesService
    {
        Task<IEnumerable<GetAllMachinesAcrossAllSystemsDto>> GetAll();
        Task<GetMachineByIdDto?> GetById(int id);
        Task<IEnumerable<GetMachinesBySystemIdDto>> GetMachinesBySystemId(int systemId);
        Task AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto);
        Task<List<GetMachineByMachineTypeIdDto>> GetMachinesByMachineTypeId(int machineTypeId);
        Task<List<MachineForSimulation>> GetMachinesForSimulation();
    }
}
