using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation
{
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _systemRepository;

        public SystemService(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }
        public GetSystemDto AddSystem(SystemRequestDto systemRequestDto)
        {
            var system = new Data.Models.System
            {
                Name = systemRequestDto.Name
            };
            var createdSystem = _systemRepository.Add(system);

            return new GetSystemDto
            {
                Id = createdSystem.Id,
                Name = createdSystem.Name
   
            };
        }

        public IEnumerable<GetSystemDto> GetAllSystems()
        {
            var systems = _systemRepository.GetAll();

            return systems.Select(s => new GetSystemDto
            {
                Id = s.Id,
                Name = s.Name,
       
            });
        }

        public GetSystemDetailsDto? GetSystemById(int id)
        {
            var system = _systemRepository.GetById(id);

            if (system == null) return null;

            return new GetSystemDetailsDto
            {
                Id = system.Id,
                Name = system.Name,
                Machines = system.Machines.Select(m => new MachinesInsideSystemDto
                {
                    Id = m.Id,
                    SerialNumber = m.SerialNumber,
                    MachineTypeName = m.MachineType.Name,
                }).ToList()
            };
        }
    }

}

