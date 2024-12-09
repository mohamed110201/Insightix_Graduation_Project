using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation
{
    public class SystemsService(ISystemsRepository systemsRepository) : ISystemsService
    {
        public async Task Add(AddSystemDto AddSystemDto)
        {
            var system = new Data.Models.System
            {
                Name = AddSystemDto.Name
            };
            await systemsRepository.Add(system);
        }

        public async Task<IEnumerable<GetAllSystemsDto>> GetAll()
        {
            var systems = await systemsRepository.GetAll();

            return systems.Select(s => new GetAllSystemsDto
            {
                Id = s.Id,
                Name = s.Name,
       
            });
        }

        public async Task<GetSystemByIdDto?> GetById(int id)
        {
            var system = await systemsRepository.GetById(id);

            if (system == null) throw new NotFoundError("System With This Id Does Not Exist");

            return new GetSystemByIdDto
            {
                Id = system.Id,
                Name = system.Name,
                Machines = system.Machines.Select(m => new GetMachinesBySystemIdDto
                {
                    Id = m.Id,
                    SerialNumber = m.SerialNumber,
                    MachineTypeName = m.MachineType.Name,
                }).ToList()
            };
        }
    }

}

