using Graduation_Project.Data.Dtos.MachineDto;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMachineTypesRepository
{
    Task<List<MachineType>> GetAll();
    Task<MachineType?> GetById(int id);
    Task Add(MachineType machineType);
    MachineType? FindByModel(string model);


}