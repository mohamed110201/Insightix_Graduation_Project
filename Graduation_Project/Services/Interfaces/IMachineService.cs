using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.SystemDto;

namespace Graduation_Project.Services.Interfaces
{
    public interface IMachineService
    {
        IEnumerable<AllMachinesAcrossAllSystemsDto> GetAllMachines();
        MachineDetailsDto? GetMachineById(int id);
        IEnumerable<MachinesInsideSystemDto> GetMachinesBySystemId(int systemId);
        MachinesInsideSystemDto AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto);

    }
}
