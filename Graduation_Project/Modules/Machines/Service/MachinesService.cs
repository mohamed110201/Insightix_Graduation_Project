using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Modules.Machines.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.Machines.Service
{
    public class MachinesService(IMachinesRepository machinesRepository,IMachineTypesRepository machineTypesRepository,ISystemsRepository systemsRepository) : IMachinesService
    {
       

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
                MachineTypeId = machine.MachineTypeId,
            };
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

        public async Task<IEnumerable<GetMachinesBySystemIdDto>> GetMachinesBySystemId(int systemId)
        {
            var system = await systemsRepository.GetById(systemId);
            if (system == null)
                throw new NotFoundError("System With This Id Does Not Exist");

            var machines = await machinesRepository.GetMachinesBySystemId(systemId);
            return machines.Select(m => new GetMachinesBySystemIdDto
            {
                Id = m.Id,
                SerialNumber = m.SerialNumber,
                MachineTypeName = m.MachineType.Name,
                MachineTypeId = m.MachineTypeId,
            }).ToList(); ;
        }

        public async Task AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto)
        {
            var system = await systemsRepository.GetById(systemId);
            if (system == null)
                throw new NotFoundError("System With This Id Does Not Exist");
            var machine = new Machine
            {
                SerialNumber = addMachineToSystemDto.SerialNumber,
                MachineTypeId = addMachineToSystemDto.MachineTypeId,
            };

            await machinesRepository.AddMachineToSystem(systemId, machine);
        }

        public async Task<List<MachineForSimulation>> GetMachinesForSimulation()
        {
            return await machinesRepository.GetMachinesForSimulation();
        }
    }
}
