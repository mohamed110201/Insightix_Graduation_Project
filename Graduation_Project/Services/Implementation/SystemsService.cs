using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation
{
    public class SystemsService(ISystemsRepository systemsRepository) : ISystemsService
    {
        public async Task Add(SystemRequestDto systemRequestDto)
        {
            var system = new Data.Models.System
            {
                Name = systemRequestDto.Name
            };
            await systemsRepository.Add(system);
        }

        public async Task<IEnumerable<GetSystemDto>> GetAll()
        {
            var systems = await systemsRepository.GetAll();

            return systems.Select(s => new GetSystemDto
            {
                Id = s.Id,
                Name = s.Name,
       
            });
        }

        public async Task<GetSystemDetailsDto?> GetById(int id)
        {
            var system = await systemsRepository.GetById(id);

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

