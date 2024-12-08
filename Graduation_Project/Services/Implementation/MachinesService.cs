using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation
{
    public class MachinesService(IMachinesRepository machinesRepository,IMachineTypesRepository machineTypesRepository) : IMachinesService
    {
        public async Task AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto)
        {
            var machine = new Machine
            {
                SerialNumber = addMachineToSystemDto.SerialNumber,
                //MachineTypeId = addMachineToSystemDto.MachineTypeId,
            };

            await machinesRepository.AddMachineToSystem(systemId, machine);
        }

        public async Task<List<MachineTypeMachineResponseDto>> GetMachinesByMachineTypeId(int machineTypeId)
        {
            var machineType = await machineTypesRepository.GetById(machineTypeId);
            if (machineType == null)
            {
                throw new NullReferenceException();
            }
            var machines = await machinesRepository.GetMachinesByMachineTypeId(machineTypeId);

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

        public async Task<IEnumerable<AllMachinesAcrossAllSystemsDto>> GetAll()
        {
             var machines = await machinesRepository.GetAll();

            return machines.Select(m => new AllMachinesAcrossAllSystemsDto
            {
                Id = m.Id,
                SystemName=m.System.Name,
                SerialNumber=m.SerialNumber,
                MachineTypeName=m.MachineType.Name,

            });
        }

        public async Task<MachineDetailsDto?> GetById(int id)
        { 
            var machine = await machinesRepository.GetById(id);

            if (machine == null) return null;

            return new MachineDetailsDto
            {
                Id = machine.Id,
                SystemName = machine.System.Name,
                SerialNumber = machine.SerialNumber,
                MachineTypeName = machine.MachineType.Name,
            };
        }

        public async Task<IEnumerable<MachinesInsideSystemDto>> GetMachinesBySystemId(int systemId)
        {
            var machines = await machinesRepository.GetMachinesBySystemId(systemId);
            return machines.Select(m => new MachinesInsideSystemDto
            {
                Id = m.Id,
                SerialNumber = m.SerialNumber,
                MachineTypeName = m.MachineType.Name
            }).ToList(); ;
        }
    }
}
