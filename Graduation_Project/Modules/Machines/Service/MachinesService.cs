using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Graduation_Project.Services.Implementation
{
    public class MachinesService(IMachinesRepository machinesRepository,IMachineTypesRepository machineTypesRepository) : IMachinesService
    {
        public async Task AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto)
        {
            var machine = new Machine
            {
                SerialNumber = addMachineToSystemDto.SerialNumber,
                MachineTypeId = addMachineToSystemDto.MachineTypeId,
            };

            await machinesRepository.AddMachineToSystem(systemId, machine);
        }

        public async Task<List<GetMachineByMachineTypeIdDto>> GetMachinesByMachineTypeId(int machineTypeId)
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

            var machinesDto = machines.Select(m => new GetMachineByMachineTypeIdDto()
            {
                Id = m.Id,
                SystemId = m.SystemId,
                SerialNumber = m.SerialNumber
            });
            return machinesDto.ToList();    
        }

        public async Task<IEnumerable<GetAllMachinesAcrossAllSystemsDto>> GetAll()
        {
             var machines = await machinesRepository.GetAll();

            return machines.Select(m => new GetAllMachinesAcrossAllSystemsDto
            {
                Id = m.Id,
                SystemName=m.System.Name,
                SerialNumber=m.SerialNumber,
                MachineTypeName=m.MachineType.Name,

            });
        }

        public async Task<GetMachineByIdDto?> GetById(int id)
        { 
            var machine = await machinesRepository.GetById(id);

            if (machine == null)
                throw new NotFoundError("Machine With This Id Does Not Exist");

            return new GetMachineByIdDto
            {
                Id = machine.Id,
                SystemName = machine.System.Name,
                SerialNumber = machine.SerialNumber,
                MachineTypeName = machine.MachineType.Name,
            };
        }

        public async Task<IEnumerable<GetMachinesBySystemIdDto>> GetMachinesBySystemId(int systemId)
        {
            var machines = await machinesRepository.GetMachinesBySystemId(systemId);
            return machines.Select(m => new GetMachinesBySystemIdDto
            {
                Id = m.Id,
                SerialNumber = m.SerialNumber,
                MachineTypeName = m.MachineType.Name
            }).ToList(); ;
        }
    }
}
