using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public MachinesInsideSystemDto AddMachineToSystem(int systemId, AddMachineToSystemDto addMachineToSystemDto)
        {
            var machine = new Machine
            {
                SerialNumber = addMachineToSystemDto.SerialNumber,
                //MachineTypeId = addMachineToSystemDto.MachineTypeId,
            };

            var createdMachine = _machineRepository.AddMachineToSystem(systemId, machine);

            return new MachinesInsideSystemDto
            {
                Id = createdMachine.Id,
                SerialNumber = createdMachine.SerialNumber,
                MachineTypeName = createdMachine.MachineType.Name
            };
        }

        public IEnumerable<AllMachinesAcrossAllSystemsDto> GetAllMachines()
        {
             var Machines = _machineRepository.GetAll();

            return Machines.Select(m => new AllMachinesAcrossAllSystemsDto
            {
                Id = m.Id,
                SystemName=m.System.Name,
                SerialNumber=m.SerialNumber,
                MachineTypeName=m.MachineType.Name,

            });
        }

        public MachineDetailsDto? GetMachineById(int id)
        {
            var Machine = _machineRepository.GetById(id);

            if (Machine == null) return null;

            return new MachineDetailsDto
            {
                Id = Machine.Id,
                SystemName = Machine.System.Name,
                SerialNumber = Machine.SerialNumber,
                MachineTypeName = Machine.MachineType.Name,
            };
        }

        public IEnumerable<MachinesInsideSystemDto> GetMachinesBySystemId(int systemId)
        {
            var machines = _machineRepository.GetMachinesBySystemId(systemId);
            return machines.Select(m => new MachinesInsideSystemDto
            {
                Id = m.Id,
                SerialNumber = m.SerialNumber,
                MachineTypeName = m.MachineType.Name
            }).ToList(); ;


    
        }
    }
}
