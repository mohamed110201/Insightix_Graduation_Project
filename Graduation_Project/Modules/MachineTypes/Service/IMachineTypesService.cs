using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Modules.MachineTypes.DTOs;

namespace Graduation_Project.Services.Interfaces;

public interface IMachineTypesService
{
    Task<List<MachineTypeGetAllDto>> GetAll();
    Task<MachineTypeGetByIdDto?> GetById(int id);
    Task Add(MachineTypeRequestDto machineTypeRequestDto);

}